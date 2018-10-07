using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Models;

namespace KargorERP.Features.Accounts
{
    public class ViewAllAccountsFeature : BaseFeature
    {
        protected ApplicationContext _ctx;

        public ViewAllAccountsFeature(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Account>> Execute()
        {
            return await _ctx.Accounts.ToListAsync();
        }
    }
}