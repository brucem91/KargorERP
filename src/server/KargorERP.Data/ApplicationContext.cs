using Microsoft.EntityFrameworkCore;

using KargorERP.Data.Models.Accounts;
using KargorERP.Data.Models.Orders;
using KargorERP.Data.Models.Users;

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
    }
}