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

        public async Task<List<Account>> GetAll(QueryContext queryContext)
        {
            return await _ctx.Accounts.WithQueryContext(queryContext).ToListAsync();
        }
    }
}