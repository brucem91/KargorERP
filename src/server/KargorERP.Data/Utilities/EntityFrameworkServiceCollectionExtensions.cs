using System;
using System.Data.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace KargorERP.Data.Utilities
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        private const string MySql = "mysql";
        private const string Postgres = "postgres";
        private const string SqlServer = "mssql";

        public static void AddApplicationContext(this IServiceCollection serviceCollection)
        {
            var client = GetEnvironmentVariable("DB_CLIENT");

            serviceCollection.AddDbContext<ApplicationContext>(opt =>
            {
                var conn = GetConnectionString(client);

                if (client == MySql) opt.UseMySql(conn);
                if (client == Postgres) opt.UseNpgsql(conn);
                if (client == SqlServer) opt.UseSqlServer(conn);
            });
        }

        private static string GetConnectionString(string client)
        {
            var host = GetEnvironmentVariable("DB_HOST");
            var user = GetEnvironmentVariable("DB_USER");
            var password = GetEnvironmentVariable("DB_PASSWORD");
            var database = GetEnvironmentVariable("DB_DATABASE");
            var port = GetEnvironmentVariable("DB_PORT");

            if (client == MySql) return $"Server={host};Port={port ?? "3306"};Database={database};User={user};Password={password};";
            if (client == Postgres) return $"Host={host};Port={port ?? "5432"}Database={database};Username={user};Password={password}";
            if (client == SqlServer) return $"Server={host}, {port ?? "1433"};Database={database};User Id={user};Password={password};";

            return "";
        }

        private static string GetEnvironmentVariable(string key)
        {
            var result = (Environment.GetEnvironmentVariable(key) ?? "").Trim();

            if (key == "DB_PORT" && string.IsNullOrEmpty(result) == true)
            {
                result = null;
            }

            return result;
        }
    }
}