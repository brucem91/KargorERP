using System;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using KargorERP.Data;

namespace KargorERP.Services.Utilities
{
    public static class ApplicationContextExtensionMethods
    {
        public static async Task<EntityEntry<TEntity>> UpdateAsync<TEntity>(this ApplicationContext ctx, TEntity originalEntity, TEntity updatedEntity) where TEntity : class
        {
            await Task.Yield();

            return ctx.Update(originalEntity, updatedEntity);
        }

        public static EntityEntry<TEntity> Update<TEntity>(this ApplicationContext ctx, TEntity originalEntity, TEntity updatedEntity) where TEntity : class
        {
            return ctx.Update(originalEntity);
        }
    }
}