using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Security.Cookies;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using SmartTrip.Models;
using System.Threading.Tasks;
using Microsoft.Data.Entity.SqlServer;
using System.Collections.Generic;
using System.Security.Claims;

namespace SmartTrip
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            services.AddEntityFramework(Configuration)
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>();

            // Add Identity services to the services container.
            services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add MVC services to the services container.
            services.AddMvc();

            // Uncomment the following line to add Web API servcies which makes it easier to port Web API 2 controllers.
            // You need to add Microsoft.AspNet.Mvc.WebApiCompatShim package to project.json
            // services.AddWebApiConventions();

        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerfactory.AddConsole();

            // Add the following to the request pipeline only in development environment.
            if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

            CreateSampleData(app.ApplicationServices).Wait();

        }
        
        private static async Task CreateSampleData(IServiceProvider applicationServices)
        {
            using (var dbContext = applicationServices.GetService<ApplicationDbContext>())
            {
                var sqlServerDatabase = dbContext.Database as SqlServerDatabase;
                if (sqlServerDatabase != null)
                {

                    if (await sqlServerDatabase.EnsureCreatedAsync())
                    {
                        //add country
                        var countries = new List<Country>
                        {
                            new Country { CountryName="China"},
                            new Country { CountryName ="Usa"}

                        };


                        int i;

                        for (i = 0; i < countries.Count; i++)
                        {

                            await dbContext.Countries.AddAsync(countries.ToArray()[i]);
                        }

                        // add city
                        var cities = new List<City>
                        {
                             new City { CityName = "Chengdu"},
                             new City { CityName = "Beijing"}
                        };

                        for (i = 0; i < cities.Count; i++)
                        {
                            await dbContext.Cities.AddAsync(cities.ToArray()[i]);
                        }

                        
                        // add some users
                        var userManager = applicationServices.GetService<UserManager<ApplicationUser>>();

                        // add editor user
                        var stephen = new ApplicationUser
                        {
                            UserName = "Stephen"
                        };
                        var result = await userManager.CreateAsync(stephen, "P@ssw0rd");
                        await userManager.AddClaimAsync(stephen, new Claim("CanEdit", "true"));

                        // add normal user
                        var bob = new ApplicationUser
                        {
                            UserName = "Bob"
                        };
                        await userManager.CreateAsync(bob, "P@ssw0rd");

                    }
                }
            }
        }



    }
}
