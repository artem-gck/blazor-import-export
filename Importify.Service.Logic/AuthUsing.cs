using Importify.Access;
using Importify.Service;
using Importify.Service.Models;
using Importify.Service.ViewModels;
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

        public AuthUsing(IAuthAccess access, IConfiguration config)
        {
            _access = access;
            _key = config.GetSection("SecreteKey").Value;
            _liveTimeAccessTokenMinutes = int.Parse(config.GetSection("LiveTimeAccessTokenMinutes").Value);
            _liveTimeRefreshTokenHours = int.Parse(config.GetSection("LiveTimeRefreshTokenHours").Value);
        }
        
        public async Task<Tokens> Login(User user)
        {
            var userData = await _access.AuthUserAsync(user.Login, user.Password);

            if (userData == null)
            {
                return null;
            }

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

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
