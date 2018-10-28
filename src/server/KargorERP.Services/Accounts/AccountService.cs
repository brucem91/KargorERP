using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Data.Models.Accounts;
using KargorERP.Data.QueryHelpers;

namespace KargorERP.Services.Accounts
{
    public class AccountService : Service
    {
        protected ApplicationContext _ctx;

        public AccountService(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _ctx.Accounts.Where(x => x.DeletedOn == null).ToListAsync();
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _ctx.Add(account);
            await _ctx.SaveChangesAsync();

            return await FindAsync(account.Id);
        }

        public async Task<Account> FindAsync(Guid id)
        {
            return await _ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id && x.DeletedOn == null);
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            _ctx.Update(account);
            await _ctx.SaveChangesAsync();

            return await FindAsync(account.Id);
        }

        public async Task DestroyAsync(Account account)
        {
            _ctx.Remove(account);

            await _ctx.SaveChangesAsync();
        }
    }
}