using AutoMapper;
using Importify.Access;
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
    /// <summary>
    /// Class for authentification logic.
    /// </summary>
    /// <seealso cref="Importify.Service.IAuthUsing" />
    public class AuthUsing : IAuthUsing
    {
        private readonly IAuthAccess _authAccess;
        private readonly int _liveTimeAccessTokenMinutes;
        private readonly int _liveTimeRefreshTokenHours;
        private readonly string _key;

        private const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1;
        private const int Pbkdf2IterCount = 1000;
        private const int Pbkdf2SubkeyLength = 256 / 8;
        private const int SaltSize = 128 / 8;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthUsing"/> class.
        /// </summary>
        /// <param name="access">The access.</param>
        /// <param name="config">The configuration.</param>
        public AuthUsing(IAuthAccess access, IConfiguration config)
        {
            _authAccess = access;
            _key = config.GetSection("SecreteKey").Value;
            _liveTimeAccessTokenMinutes = int.Parse(config.GetSection("LiveTimeAccessTokenMinutes").Value);
            _liveTimeRefreshTokenHours = int.Parse(config.GetSection("LiveTimeRefreshTokenHours").Value);
        }

        /// <inheritdoc/>
        public async Task<Tokens> LoginAsync(User user)
        {
            var userData = await _authAccess.GetUserAsync(user.Login);

            if (userData is null || !CheckPassword(userData.Password, user.Password))
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userData.Login),
                new Claim(ClaimTypes.Role, userData.UserInfo.Role.Value)
            };

            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken();

            userData.RefreshToken = refreshToken;
            userData.RefreshTokenExpiryTime = DateTime.Now.AddHours(_liveTimeRefreshTokenHours);

            await _authAccess.SetNewRefreshKeyAsync(userData);

            return new Tokens()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        /// <inheritdoc/>
        public async Task<int> RegistrationAsync(User user)
        {
            var password = HashPassword(user.Password);

            var role = new Access.Entities.Role();
            role.Value = user.UserInfo.Role.Value;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, Access.Entities.UserInfo>()
                                                           .ForMember(usIn => usIn.Role, opt => opt.Ignore()));
            var mapper = new Mapper(config);

            var userInfo = mapper.Map<Access.Entities.UserInfo>(user.UserInfo);
            userInfo.Role = role;

            config = new MapperConfiguration(cfg => cfg.CreateMap<User, Access.Entities.User>()
                                                       .ForMember(us => us.UserInfo, opt => opt.Ignore())
                                                       .ForMember(us => us.Password, opt => opt.Ignore()));
            mapper = new Mapper(config);

            var userDb = mapper.Map<Access.Entities.User>(user);
            userDb.UserInfo = userInfo;
            userDb.Password = password;

            return await _authAccess.AddUserAsync(userDb);
        }

        /// <inheritdoc/>
        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _authAccess.GetUsersAsync();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Role, Role>().ForMember(r => r.UserInfo, opt => opt.Ignore()));
            var mapper = new Mapper(config);

            var userRoles = users.Select(us => mapper.Map<Role>(us.UserInfo.Role)).ToList();

            config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.UserInfo, UserInfo>().ForMember(usi => usi.User, opt => opt.Ignore())
                                                                                                           .ForMember(usi => usi.Role, opt => opt.Ignore()));
            mapper = new Mapper(config);
            
            var userInfos = users.Select(us => mapper.Map<UserInfo>(us.UserInfo)).ToList();

            for (var i = 0; i < userInfos.Count; i++)
                userInfos[i].Role = userRoles[i];

            config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.User, User>().ForMember(us => us.UserInfo, opt => opt.Ignore()));
            mapper = new Mapper(config);

            var userModels = users.Select(us => mapper.Map<User>(us)).ToList();

            for(var i = 0; i < userInfos.Count; i++)
                userModels[i].UserInfo = userInfos[i];

            return userModels;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateUserAsync(User user)
        {
            var password = HashPassword(user.Password);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, Access.Entities.UserInfo>()
                                                           .ForMember(usi => usi.User, opt => opt.Ignore()));
            var mapper = new Mapper(config);

            var userInfoModel = mapper.Map<Access.Entities.UserInfo>(user.UserInfo);


            config = new MapperConfiguration(cfg => cfg.CreateMap<User, Access.Entities.User>()
                                                       .ForMember(usi => usi.UserInfo, opt => opt.Ignore())
                                                       .ForMember(usi => usi.Massages, opt => opt.Ignore())
                                                       .ForMember(usi => usi.Password, opt => opt.Ignore()));
            mapper = new Mapper(config);

            var userModel = mapper.Map<Access.Entities.User>(user);
            userModel.UserInfo = userInfoModel;
            userModel.Password = password;

            return await _authAccess.UpdateUserAsync(userModel);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteUserAsync(User user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, Access.Entities.UserInfo>()
                                               .ForMember(usi => usi.User, opt => opt.Ignore()));
            var mapper = new Mapper(config);

            var userInfoModel = mapper.Map<Access.Entities.UserInfo>(user.UserInfo);


            config = new MapperConfiguration(cfg => cfg.CreateMap<User, Access.Entities.User>()
                                                       .ForMember(usi => usi.UserInfo, opt => opt.Ignore())
                                                       .ForMember(usi => usi.Massages, opt => opt.Ignore())
                                                       .ForMember(usi => usi.Password, opt => opt.Ignore()));
            mapper = new Mapper(config);

            var userModel = mapper.Map<Access.Entities.User>(user);

            return await _authAccess.DeleteUserAsync(userModel);
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
