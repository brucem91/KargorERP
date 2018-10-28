using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using KargorERP.Data.Models.Accounts;
using KargorERP.Services.Accounts;
using KargorERP.Utilities;
using KargorERP.ViewModels.Accounts;

namespace KargorERP.Controllers.Accounts
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        protected AccountService _accountService;

        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<List<Account>> Index()
        {
            return await _accountService.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUpdateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = new Account()
                {
                    Name = model.Name,
                    AccountNumber = model.AccountNumber,
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    AddressLine3 = model.AddressLine3
                };

                return Ok(await _accountService.CreateAsync(account));
            }

            return BadRequest(modelState: ModelState);
        }
    }
}