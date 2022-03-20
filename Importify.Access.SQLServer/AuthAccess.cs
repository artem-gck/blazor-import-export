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

        public async Task<User> AuthUserAsync(string login)
        {
            login = login is not null ? login : throw new ArgumentNullException(nameof(login));

            return await _importifyContext.Users.Include(us => us.UserInfo)
                                                .FirstOrDefaultAsync(user => user.Login == login);
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

        public async Task<List<User>> GetUsersAsync()
            => await _importifyContext.Users.Include(user => user.UserInfo)
                                            .ToListAsync();

        public async Task<int> AddUserAsync(User user)
        {
            var us = await _importifyContext.Users.AddAsync(user);
            await _importifyContext.SaveChangesAsync();

            return us.Entity.UserId;
        }
    }
}
