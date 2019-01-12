using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

using KargorERP.Data.Models.Accounts;
using KargorERP.Data.Models.Identity;
using KargorERP.Data.Models.Orders;

namespace KargorERP.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<UserSessionToken> UserSessionTokens { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                var entity = entry.Entity as KargorERP.Data.Models.Model;

                entity.CreatedOn = now;
                entity.UpdatedOn = now;
            }

            foreach (var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Modified))
            {
                (entry.Entity as KargorERP.Data.Models.Model).UpdatedOn = now;
            }

            foreach (var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Modified;
                (entry.Entity as KargorERP.Data.Models.Model).DeletedOn = now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotSupportedException();
        }
    }
}