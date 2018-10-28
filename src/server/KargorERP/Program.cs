using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using KargorERP.Utilities;

namespace KargorERP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EnvironmentUtilities.LoadEnvironmentFromFile();
            System.Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "PRODUCTION");

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}