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

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}