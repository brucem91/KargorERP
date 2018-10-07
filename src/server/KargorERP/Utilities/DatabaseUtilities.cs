using System;

namespace KargorERP.Utilities
{
    public static class DatabaseUtilities
    {
        public static string Client { get { return (Environment.GetEnvironmentVariable("DB_CLIENT") ?? "").ToLower().Trim(); } }
        private static string Host { get { return Environment.GetEnvironmentVariable("DB_HOST") ?? ""; ; } }
        private static string User { get { return Environment.GetEnvironmentVariable("DB_USER") ?? ""; ; } }
        private static string Password { get { return Environment.GetEnvironmentVariable("DB_PASSWORD") ?? ""; ; } }
        private static string Database { get { return Environment.GetEnvironmentVariable("DB_DATABASE") ?? ""; ; } }
        private static string Port { get { return Environment.GetEnvironmentVariable("DB_PORT") ?? ""; ; } }

        public const string MySqlClient = "mysql";
        public const string SqlServerClient = "mssql";
        public const string PostgresClient = "postgres";

        public static string ConnectionString
        {
            get
            {
                if (Client == MySqlClient) return $"Server={Host};Database={Database};User={User};Password={Password};";
                if (Client == PostgresClient) return $"Host={Host};Database={Database};Username={User};Password={Password}";
                if (Client == SqlServerClient) return $"Server={Host};Database={Database};User Id={User};Password={Password};";

                return "";
            }
        }
    }
}