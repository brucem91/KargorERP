using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using KargorERP.Data;
using KargorERP.Data.QueryHelpers;

namespace KargorERP.Services.Resources
{
    public class ResourceService<T> : Service where T : class
    {
        protected ApplicationContext _ctx;

        public ResourceService(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<T>> FetchAll()
        {
            var query = _ctx.Set<T>().AsQueryable();

            return await query.ToListAsync();
        }
    }
}