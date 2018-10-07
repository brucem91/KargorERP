using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Models;

namespace KargorERP.Features.Accounts
{
    public class DestroyAccountFeature : BaseFeature
    {
        protected ApplicationContext _ctx;

        public DestroyAccountFeature(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Execute(Guid id)
        {
            var account = await _ctx.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (account == null) throw new DllNotFoundException();

            var errors = await CanAccountBeDestroyed(account);
        }

        private async Task<List<string>> CanAccountBeDestroyed(Account account)
        {
            var errors = new List<string>();

            return errors;
        }
    }
}