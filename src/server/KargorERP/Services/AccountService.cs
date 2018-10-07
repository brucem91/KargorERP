using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Features.Accounts;
using KargorERP.Models;
using KargorERP.ViewModels;

namespace KargorERP.Services
{
    public class AccountService : BaseService
    {
        protected ViewAllAccountsFeature _viewAllAccountsFeature;

        public AccountService(ViewAllAccountsFeature viewAllAccountsFeature)
        {
            _viewAllAccountsFeature = viewAllAccountsFeature;
        }

        public async Task<List<Account>> ViewAllAccounts()
        {
            return await _viewAllAccountsFeature.Execute();
        }
    }
}