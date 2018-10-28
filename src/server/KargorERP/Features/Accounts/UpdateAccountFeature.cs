using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Data.Models.Accounts;
using KargorERP.ViewModels;

namespace KargorERP.Features.Accounts
{
    public class UpdateAccountFeature : BaseFeature
    {
        protected ApplicationContext _ctx;
        protected ViewOneAccountFeature _viewOneAccountFeature;

        public UpdateAccountFeature(ApplicationContext ctx, ViewOneAccountFeature viewOneAccountFeature)
        {
            _ctx = ctx;
            _viewOneAccountFeature = viewOneAccountFeature;
        }

        public async Task<Account> Execute(Guid id, CreateAccountViewModel model)
        {
            var account = await _viewOneAccountFeature.Execute(id);
            if (account == null) return null;

            account.Name = model.Name;
            account.AccountNumber = model.AccountNumber;
            account.AddressLine1 = model.AddressLine1;
            account.AddressLine2 = model.AddressLine2;
            account.AddressLine3 = model.AddressLine3;
            account.UpdatedOn = DateTime.UtcNow;

            await _ctx.SaveChangesAsync();

            return await _viewOneAccountFeature.Execute(id);
        }
    }
}