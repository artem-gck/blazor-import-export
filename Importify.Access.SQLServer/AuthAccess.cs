using Importify.Access.Context;
using Importify.Access.Entities;
using Microsoft.EntityFrameworkCore;

namespace Importify.Access.SQLServer
{
    /// <summary>
    /// Class for authentification access in SQL Server.
    /// </summary>
    /// <seealso cref="Importify.Access.IAuthAccess" />
    public class AuthAccess : IAuthAccess
    {
        private readonly ImportifyContext _importifyContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthAccess"/> class.
        /// </summary>
        /// <param name="importifyContext">The importify context.</param>
        public AuthAccess(ImportifyContext importifyContext)
            => _importifyContext = importifyContext;

        /// <inheritdoc/>
        public async Task<User> GetUserAsync(string login)
        {
            login = login is not null ? login : throw new ArgumentNullException(nameof(login));

            return await _importifyContext.Users.Include(us => us.UserInfo)
                                                .ThenInclude(usIn => usIn.Role)
                                                .FirstOrDefaultAsync(user => user.Login == login);
        }

        /// <inheritdoc/>
        public async Task<bool> SetNewRefreshKeyAsync(User user)
        {
            user = user is not null ? user : throw new ArgumentNullException(nameof(user));

            var userData = await _importifyContext.Users.FirstOrDefaultAsync(userData => userData.Login == user.Login);

            userData.RefreshToken = user.RefreshToken;
            userData.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;

            await _importifyContext.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<List<User>> GetUsersAsync()
            => await _importifyContext.Users.Include(user => user.UserInfo)
                                            .ThenInclude(usIn => usIn.Role)
                                            .ToListAsync();

        /// <inheritdoc/>
        public async Task<int> AddUserAsync(User user)
        {
            user.UserInfo.Role = await GetRole(user.UserInfo.Role.Value);

            var us = await _importifyContext.Users.AddAsync(user);
            await _importifyContext.SaveChangesAsync();

            return us.Entity.UserId;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateUserAsync(User user)
        {
            var us = await _importifyContext.Users.Include(user => user.UserInfo)
                                                  .ThenInclude(usIn => usIn.Role)
                                                  .FirstOrDefaultAsync(us => us.Login == user.Login);

            us.Login = user.Login;
            us.Password = user.Password;
            us.UserInfo.UserInfoId = user.UserInfo.UserInfoId;
            us.UserInfo.NumberOfPhone = user.UserInfo.NumberOfPhone;
            us.UserInfo.Email = user.UserInfo.Email;

            var role = await GetRole(user.UserInfo.Role.Value);
            us.UserInfo.Role = role;

            await _importifyContext.SaveChangesAsync();

            return us.UserId;
        }

        /// <inheritdoc/>
        public async Task<int> DeleteUserAsync(int id)
        {
            var us = await _importifyContext.Users.FirstOrDefaultAsync(us => us.UserId == id);

            _importifyContext.Users.Remove(us);
            await _importifyContext.SaveChangesAsync();

            return us.UserId;
        }

        private async Task<Role> GetRole(string role)
        {
            var roleDb = await _importifyContext.Roles.FirstOrDefaultAsync(r => r.Value == role);

            if (roleDb is null)
            {
                var newRole = new Role()
                {
                    Value = role
                };

                var ro = await _importifyContext.AddAsync(newRole);

                return ro.Entity;
            }

            return roleDb;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _importifyContext.Roles.ToListAsync();
        }
    }
}
