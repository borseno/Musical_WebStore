using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Musical_WebStore_BlazorApp.Server.Data;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Server.Helpers;
using Musical_WebStore_BlazorApp.Server.Services;
using System;
using System.Linq;
using System.Text;

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
            AddDatabaseProvider(services);
            AddIdentity(services);
            AddCompression(services);
            AddAuthentication(services);

            services.AddMvc().AddNewtonsoftJson();
            services.AddTransient<IEmailSender, MockeeMockersEmailSender>();
            services.AddTransient<IFileSavingService, FileSavingService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();

            }
            
            if (Configuration.GetDatabaseType() == DatabaseType.InMemory)
            {
                EnsureDatabaseCreated(app.ApplicationServices);
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
        }

        private void EnsureDatabaseCreated(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetService<MusicalShopIdentityDbContext>();
            context.Database.EnsureCreated();
        }

        private void AddAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                {
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidateAudience = true,
                                        ValidateLifetime = true,
                                        ValidateIssuerSigningKey = true,
                                        ValidIssuer = Configuration["JwtIssuer"],
                                        ValidAudience = Configuration["JwtAudience"],
                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]))
                                    };
                                });
        }

        private static void AddCompression(IServiceCollection services)
        {
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        private static void AddIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<User>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MusicalShopIdentityDbContext>()
              .AddDefaultTokenProviders();
        }

        private void AddDatabaseProvider(IServiceCollection services)
        {
            var databaseType = Configuration.GetDatabaseType();

            if (databaseType == DatabaseType.InMemory)
            {
                services.AddDbContext<MusicalShopIdentityDbContext>(
                    options => options.UseInMemoryDatabase("random_name"));
            }
            if (databaseType == DatabaseType.SQLSERVER)
            {                
                var connStr = GetConnectionString(databaseType);

                services.AddDbContext<MusicalShopIdentityDbContext>(
                    options => options.UseSqlServer(connStr));
            }
        }

        private string GetConnectionString(DatabaseType type)
        {
            string dbName;

            if (Environment.IsDevelopment())
            {
                dbName = $"{(int)type}_AuthenticationDB_Local";
            }
            else
            {
                dbName = $"{(int)type}_AuthenticationDB";
            }

            return Configuration.GetConnectionString(dbName);
        }
    }
}
