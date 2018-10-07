using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Models;
using KargorERP.Services;
using KargorERP.ViewModels;

namespace KargorERP.Controllers
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
            return await _accountService.ViewAllAccounts();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountService.CreateAccount(model));
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<Account> Get(Guid id)
        {
            return await _accountService.ViewOneAccount(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountService.UpdateAccount(id, model));
            }

            return BadRequest(ModelState);
        }
    }
}