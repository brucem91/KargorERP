using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

using KargorERP.Data;
using KargorERP.Features;
using KargorERP.Utilities;
using KargorERP.Services;

namespace KargorERP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationContext>(opt =>
            {
                if (DatabaseUtilities.Client == DatabaseUtilities.MySqlClient) opt.UseMySql(DatabaseUtilities.ConnectionString);
                if (DatabaseUtilities.Client == DatabaseUtilities.PostgresClient) opt.UseNpgsql(DatabaseUtilities.ConnectionString);
                if (DatabaseUtilities.Client == DatabaseUtilities.SqlServerClient) opt.UseSqlServer(DatabaseUtilities.ConnectionString);
            });

            services.RegisterAllClassesThatInheritType<BaseFeature>();
            services.RegisterAllClassesThatInheritType<BaseService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Default/Error");
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
