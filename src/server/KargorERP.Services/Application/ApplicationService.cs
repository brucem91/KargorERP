using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Data.Models.Accounts;
using KargorERP.Data.QueryHelpers;

namespace KargorERP.Services.Application
{
    public class ApplicationService : Service
    {
        protected ApplicationContext _ctx;

        public ApplicationService(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async void Initialize()
        {
            
        }
    }
}