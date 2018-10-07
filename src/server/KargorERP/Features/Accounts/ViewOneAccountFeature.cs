using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Models;

namespace KargorERP.Features.Accounts
{
    public class ViewOneAccountFeature : BaseFeature
    {
        protected ApplicationContext _ctx;

        public ViewOneAccountFeature(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Account> Execute(Guid id)
        {
            return await _ctx.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
        }
    }
}