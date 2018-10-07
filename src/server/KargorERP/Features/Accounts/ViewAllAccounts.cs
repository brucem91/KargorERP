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

namespace KargorERP.Features.Accounts
{
    public class ViewAllAccountsFeature
    {
        protected ApplicationContext _ctx;

        public ViewAllAccountsFeature(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Account>> Execute()
        {
            return await _ctx.Accounts.ToListAsync();
        }
    }
}