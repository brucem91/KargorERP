using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Data.Models.Identity;

namespace KargorERP.Services.Identity
{
    public class UserService : Service
    {
        protected readonly ApplicationContext _ctx;
        protected readonly UserPasswordService _userPasswordService;

        public UserService(ApplicationContext ctx, UserPasswordService userPasswordService)
        {
            _ctx = ctx;
            _userPasswordService = userPasswordService;
        }

        public async Task<User> CreateAsync(User newUser, string newUserPassword = "", bool notifyUser = false)
        {
            var user = new User()
            {
                Name = newUser.Name,
                EmailAddress = newUser.EmailAddress,
                PhoneNumber = newUser.PhoneNumber
            };

            _ctx.Users.Add(user);

            if (string.IsNullOrEmpty(newUserPassword) == false)
            {
                var password = new UserPassword()
                {
                    Password = _userPasswordService.HashPassword(user, newUserPassword)
                };

                _ctx.UserPasswords.Add(password);
            }

            await _ctx.SaveChangesAsync();
            return await FindAsync(user.Id);
        }

        public async Task<User> FindAsync(Guid id)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Id == id && x.DeletedOn == null);
        }
    }
}