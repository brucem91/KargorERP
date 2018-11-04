using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Data.Models.Application;
using KargorERP.Data.Models.Identity;
using KargorERP.Data.QueryHelpers;
using KargorERP.Services.Identity;

namespace KargorERP.Services.Application
{
    public class ApplicationService : Service
    {
        protected ApplicationContext _ctx;
        protected UserService _userService;

        public ApplicationService(ApplicationContext ctx, UserService userService)
        {
            _ctx = ctx;
            _userService = userService;
        }

        public async Task<ApplicationStatus> GetApplicationStatusAsync()
        {
            var query = from u in _ctx.Users
                        select u.Id;

            return new ApplicationStatus()
            {
                IsInitialized = (await query.Take(1).AnyAsync())
            };
        }

        public async Task<ApplicationStatus> InitializedApplicationAsync(string Name, string EmailAddress, string PhoneNumber, string Password)
        {
            var user = new User()
            {
                Name = Name,
                EmailAddress = EmailAddress,
                PhoneNumber = PhoneNumber
            };

            await _userService.CreateAsync(user, Password, false);
            return await GetApplicationStatusAsync();
        }
    }
}