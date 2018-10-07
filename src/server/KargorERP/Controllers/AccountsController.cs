using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Models;
using KargorERP.ViewModels;

namespace KargorERP.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        protected ApplicationContext _ctx;

        public AccountsController(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<List<Account>> Index()
        {
            return await _ctx.Accounts.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
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

                return Ok(account);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var account = await _ctx.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (account == null) return NotFound();

            return Ok(account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateAccountViewModel model)
        {
            var account = await _ctx.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (account == null) return NotFound();

            if (ModelState.IsValid)
            {
                account.Name = model.Name;
                account.AddressLine1 = model.AddressLine1;
                account.AddressLine2 = model.AddressLine2;
                account.AddressLine3 = model.AddressLine3;
                account.UpdatedOn = DateTime.UtcNow;

                await _ctx.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}