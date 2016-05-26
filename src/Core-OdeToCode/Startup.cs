using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Core_OdeToCode.Services;
using Microsoft.AspNet.Routing;
using Core_OdeToCode.Entities;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.PlatformAbstractions;

namespace Core_OdeToCode
{
    public class Startup
    {
        IConfiguration Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /* 03: Now get the same piece of code from service */
            /* Every method rather then instantiating a class that will ask from dependency injection provider to give an object.
             * You also need to add your service details
             * services.AddTransient: for every create new and pass it
             * services.AddScoped: each http request should get its own object.
             * services.AddSingleton can also takes in lambda and it is smart and know what interface it is building
             */
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton(provider => Configuration);

            // Entity Setting
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<OdeToCodeDbContext>(options => options.UseSqlServer(Configuration["database:connection"]));

            // Add MVC
            services.AddMvc();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();

            // Identity Services
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<OdeToCodeDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IGreeter greeter, IHostingEnvironment environment
            , IApplicationEnvironment appEnvironment)
        {
            #region 01 Initial Project
            /*****************************************************/
            /* 01: Initial Project */
            //app.UseIISPlatformHandler();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            #endregion
            #region 02 Read configuration Directly
            /*****************************************************/
            /* 02: Lets read the configuration from appsettings.json */
            //app.UseIISPlatformHandler();
            //app.Run(async (context) =>
            //{
            //    var greeting = Configuration["greeting"];
            //    await context.Response.WriteAsync(greeting);
            //});
            #endregion
            #region Read configuration from Service
            /*****************************************************/
            /* 03: Now get the same piece of code from service */
            /* Add new interface in method IGreeting in Configure Method */
            //app.UseIISPlatformHandler();
            //app.Run(async (context) =>
            //{
            //    var greeting = greeter.GetGreeting();
            //    await context.Response.WriteAsync(greeting);
            //});
            #endregion
            /*****************************************************/
            /* Setup */
            app.UseIISPlatformHandler();

            // Exception Handling to see stack trace on page
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Runtime Information
            app.UseRuntimeInfoPage("/info");
            // use static file from root folder
            // app.UseDefaultFiles();
            // app.UseStaticFiles();
            // But better to use if not sure about order of above two middleware
            //app.UseFileServer();
            app.UseNodeModules(appEnvironment);
            app.UseIdentity();
            // MVC system
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });

        }

        private void ConfigureRoutes(IRouteBuilder routeBilder)
        {
            routeBilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
