using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Data.Models.Identity;

namespace KargorERP.Services.IdentityService
{
    public class IdentityService
    {
        protected readonly ApplicationContext _ctx;
        protected readonly IHttpContextAccessor _context;
        protected readonly string _tokenName;
        private User _currentUser = null;

        public IdentityService(ApplicationContext ctx, IHttpContextAccessor context)
        {
            _context = context;
            _ctx = ctx;
            _tokenName = "x-access-token";
        }

        public async Task<User> FetchCurrentUser()
        {
            if (_currentUser != null) return _currentUser;

            var token = "";

            if (_context != null)
            {
                if (string.IsNullOrEmpty(token)) token = _context.HttpContext.Request.Query[_tokenName];
                if (string.IsNullOrEmpty(token)) token = _context.HttpContext.Request.Headers[_tokenName];
            }

            return await FetchCurrentUser(token);
        }

        private async Task<User> FetchCurrentUser(string token)
        {
            if (string.IsNullOrEmpty(token) == false)
            {
                var query = from t in _ctx.UserSessionTokens
                            join u in _ctx.Users on t.UserId equals u.Id
                            where t.Token == token
                            where t.DeletedOn == null
                            where u.DeletedOn == null
                            select u;

                _currentUser = await query.FirstOrDefaultAsync();

            }

            return _currentUser;
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }
    }
}