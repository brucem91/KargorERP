using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using KargorERP.Data.Models.Accounts;
using KargorERP.Services.Resources;
using KargorERP.ViewModels;

namespace KargorERP.Controllers.Accounts
{
    public class AccountsController : ResourceController<Account>
    {

        public AccountsController(ResourceService<Account> resourceService) : base(resourceService)
        {

        }
    }
}