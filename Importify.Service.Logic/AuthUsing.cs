using AutoMapper;
using Importify.Access;
using Importify.Service;
using Importify.Service.Models;
using Importify.Service.ViewModels;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Importify.Service.Logic
{
    public class AuthUsing : IAuthUsing
    {
        private readonly IAuthAccess _access;
        private readonly int _liveTimeAccessTokenMinutes;
        private readonly int _liveTimeRefreshTokenHours;
        private readonly string _key;

        private const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1;
        private const int Pbkdf2IterCount = 1000;
        private const int Pbkdf2SubkeyLength = 256 / 8;
        private const int SaltSize = 128 / 8;

        public AuthUsing(IAuthAccess access, IConfiguration config)
        {
            _access = access;
            _key = config.GetSection("SecreteKey").Value;
            _liveTimeAccessTokenMinutes = int.Parse(config.GetSection("LiveTimeAccessTokenMinutes").Value);
            _liveTimeRefreshTokenHours = int.Parse(config.GetSection("LiveTimeRefreshTokenHours").Value);
        }

        public async Task<Tokens> LoginAsync(User user)
        {
            var userData = await _access.AuthUserAsync(user.Login);

            if (userData is null || !CheckPassword(userData.Password, user.Password))
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userData.Login),
                new Claim(ClaimTypes.Role, "Manager")
            };

            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken();

            userData.RefreshToken = refreshToken;
            userData.RefreshTokenExpiryTime = DateTime.Now.AddHours(_liveTimeRefreshTokenHours);

            await _access.SetNewRefreshKeyAsync(userData);

            return new Tokens()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<int> RegistrationAsync(User user)
        {
            var password = HashPassword(user.Password);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, Access.Entities.UserInfo>());
            var mapper = new Mapper(config);

            var userInfo = mapper.Map<Access.Entities.UserInfo>(user.UserInfo);

            config = new MapperConfiguration(cfg => cfg.CreateMap<User, Access.Entities.User>()
                                                       .ForMember(us => us.UserInfo, opt => opt.Ignore())
                                                       .ForMember(us => us.Password, opt => opt.Ignore()));
            mapper = new Mapper(config);

            var userDb = mapper.Map<Access.Entities.User>(user);
            userDb.UserInfo = userInfo;
            userDb.Password = password;

            return await _access.AddUserAsync(userDb);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _access.GetUsersAsync();
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.UserInfo, UserInfo>().ForMember(usi => usi.User, opt => opt.Ignore()));
            var mapper = new Mapper(config);

            var userInfos = users.Select(us => mapper.Map<UserInfo>(us.UserInfo)).ToList();

            config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.User, User>().ForMember(us => us.UserInfo, opt => opt.Ignore()));
            mapper = new Mapper(config);

            var userModels = users.Select(us => mapper.Map<User>(us)).ToList();

            for(var i = 0; i < userInfos.Count; i++)
                userModels[i].UserInfo = userInfos[i];

            return userModels;
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: claims,
                expires: DateTime.Now.AddMinutes(_liveTimeAccessTokenMinutes),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        private static byte[] HashPassword(string password)
        {
            using var rngCsp = new RNGCryptoServiceProvider();

            var salt = new byte[SaltSize];

            rngCsp.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
            outputBytes[0] = 0x00;
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);

            return outputBytes;
        }

        private static bool CheckPassword(byte[] hashPassword, string password)
        {
            if (hashPassword.Length != 1 + SaltSize + Pbkdf2SubkeyLength)
                return false;

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(hashPassword, 1, salt, 0, salt.Length);

            byte[] expectedSubkey = new byte[Pbkdf2SubkeyLength];
            Buffer.BlockCopy(hashPassword, 1 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
        }
    }
}
