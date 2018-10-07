using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Models;
using KargorERP.ViewModels;

namespace KargorERP.Features.Accounts
{
    public class CreateAccountFeature : BaseFeature
    {
        protected ApplicationContext _ctx;
        protected ViewOneAccountFeature _viewOneAccountFeature;

        public CreateAccountFeature(ApplicationContext ctx, ViewOneAccountFeature viewOneAccountFeature)
        {
            _ctx = ctx;
            _viewOneAccountFeature = viewOneAccountFeature;
        }

        public async Task<Account> Execute(CreateAccountViewModel model)
        {
            var account = new Account()
            {
                Name = model.Name,
                AccountNumber = model.AccountNumber,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AddressLine3 = model.AddressLine3,
                CreatedOn = DateTime.UtcNow
            };

            account.UpdatedOn = account.CreatedOn;

            _ctx.Accounts.Add(account);
            await _ctx.SaveChangesAsync();

            return await _viewOneAccountFeature.Execute(account.AccountId);
        }
    }
}