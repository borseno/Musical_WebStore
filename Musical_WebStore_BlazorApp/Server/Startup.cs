using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Musical_WebStore_BlazorApp.Client;
using Musical_WebStore_BlazorApp.Server.Controllers;
using Musical_WebStore_BlazorApp.Server.Data;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Server.Helpers;
using Musical_WebStore_BlazorApp.Server.Services;
using Telegram.Bot;

namespace Musical_WebStore_BlazorApp.Server
{

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseProvider(Configuration, Environment);
            services.AddIdentity();
            services.AddCompression();
            services.AddAuthentication(Configuration);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().AddNewtonsoftJson();
            services.AddTransient<IEmailSender, MockeeMockersEmailSender>();
            services.AddTransient<IFileSavingService, FileSavingService>();
            services.AddScoped<ITestEnrollingService, TestEnrollingService>();
            services.AddScoped<IAdminNotificationService, TelegramBotNotificationService>(
                u => new TelegramBotNotificationService(
                    new TelegramBotClient("976707251:AAFwjyl8HMsMtpYUS9bVRug1Ywal5RiBwHg"),
                    Configuration.GetAdminGroupId())
            );
            services.AddScoped<ITestingService, TestingService>();
            services.AddScoped<ITestingInfoService, TestingInfoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<User> um, RoleManager<IdentityRole> rm)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            if (Configuration.GetDatabaseType() == DatabaseType.InMemory)
            {
                StartupHelper.EnsureDatabaseCreated<MusicalShopIdentityDbContext>(app.ApplicationServices);
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });

            if (env.IsDevelopment())
            {
                IdentityDataInitializer.SeedData(um, rm);
            }
        }

    }
}
