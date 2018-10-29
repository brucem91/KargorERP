using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using KargorERP.Data.Models.Accounts;
using KargorERP.Services.Application;
using KargorERP.Utilities;
using KargorERP.ViewModels.Application;

namespace KargorERP.Controllers
{
    [Route("api/application")]
    public class ApplicationController : Controller
    {
        [HttpPost("initialize")]
        public async Task<IActionResult> Post(InitializeApplicationViewModel model)
        {
            return Ok();
        }
    }
}