using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using KargorERP.Data.Models.Application;
using KargorERP.Services.Application;
using KargorERP.Utilities;
using KargorERP.ViewModels.Application;

namespace KargorERP.Controllers
{
    [Route("api/application")]
    public class ApplicationController : Controller
    {
        protected ApplicationService _appService;

        public ApplicationController(ApplicationService appService)
        {
            _appService = appService;
        }

        [HttpGet("status")]
        public async Task<ApplicationStatus> GetApplicationStatus()
        {
            return await _appService.GetApplicationStatusAsync();
        }

        [HttpPost("initialize")]
        public async Task<ApplicationStatus> InitializeApplication(InitializeApplicationViewModel model)
        {
            return await _appService.InitializedApplicationAsync(model.Name, model.EmailAddress, model.PhoneNumber, model.Password);
        }
    }
}