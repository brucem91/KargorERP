using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Features.Accounts;
using KargorERP.Data.Models.Accounts;
using KargorERP.ViewModels;

namespace KargorERP.Services
{
    public class AccountService : BaseService
    {
        protected ViewAllAccountsFeature _viewAllAccountsFeature;
        protected ViewOneAccountFeature _viewOneAccountFeature;
        protected CreateAccountFeature _createAccountFeature;
        protected UpdateAccountFeature _updateAccountFeature;

        public AccountService(ViewAllAccountsFeature viewAllAccountsFeature, ViewOneAccountFeature viewOneAccountFeature, CreateAccountFeature createAccountFeature, UpdateAccountFeature updateAccountFeature)
        {
            _viewAllAccountsFeature = viewAllAccountsFeature;
            _viewOneAccountFeature = viewOneAccountFeature;
            _createAccountFeature = createAccountFeature;
            _updateAccountFeature = updateAccountFeature;
        }

        public async Task<List<Account>> ViewAllAccounts()
        {
            return await _viewAllAccountsFeature.Execute();
        }

        public async Task<Account> CreateAccount(CreateAccountViewModel model)
        {
            return await _createAccountFeature.Execute(model);
        }

        public async Task<Account> ViewOneAccount(Guid id)
        {
            return await _viewOneAccountFeature.Execute(id);
        }

        public async Task<Account> UpdateAccount(Guid id, CreateAccountViewModel model)
        {
            return await _updateAccountFeature.Execute(id, model);
        }
    }
}