using Importify.Access.Context;
using Importify.Access.Entities;
using Microsoft.EntityFrameworkCore;

namespace Importify.Access.SQLServer
{
    public class AuthAccess : IAuthAccess
    {
        private readonly ImportifyContext _importifyContext;

        public AuthAccess(ImportifyContext importifyContext)
            => _importifyContext = importifyContext;

        public async Task<User> AuthUserAsync(string login, string password)
        {
            login = login is not null ? login : throw new ArgumentNullException(nameof(login));

            return await _importifyContext.Users.FirstOrDefaultAsync(user => user.Login == login && user.Password == password);
        }

        public async Task<User> GetUserAsync(string login)
        {
            login = login is not null ? login : throw new ArgumentNullException(nameof(login));

            return await _importifyContext.Users.FirstOrDefaultAsync(user => user.Login == login);
        }

        public async Task<bool> SetNewRefreshKeyAsync(User user)
        {
            user = user is not null ? user : throw new ArgumentNullException(nameof(user));

            var userData = await _importifyContext.Users.FirstOrDefaultAsync(userData => userData.Login == user.Login);

            userData.RefreshToken = user.RefreshToken;
            userData.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;

            await _importifyContext.SaveChangesAsync();

            return true;
        }
    }
}
