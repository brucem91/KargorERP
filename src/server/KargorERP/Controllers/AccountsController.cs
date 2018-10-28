using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using KargorERP.Data.Models.Accounts;
using KargorERP.Services.Accounts;
using KargorERP.Utilities;
using KargorERP.ViewModels;

namespace KargorERP.Controllers.Accounts
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        protected AccountService _accountService;

        public AccountsController(AccountService accountService)
        {
            accountService = _accountService;
        }

        [HttpGet]
        public async Task<List<Account>> Index()
        {
            return await _accountService.GetAll(null);
        }
    }
}