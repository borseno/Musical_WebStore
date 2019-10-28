using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Musical_WebStore_BlazorApp.Server.Data;
using Musical_WebStore_BlazorApp.Server.Data.Models;
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();

                EnsureDatabaseCreated(app);
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

        private void EnsureDatabaseCreated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
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
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<MusicalShopIdentityDbContext>(
                    options => options.UseInMemoryDatabase("mmmm"));
            }
            else
            {
                var connStr = GetConnectionString();

                services.AddDbContext<MusicalShopIdentityDbContext>(
                    options => options.UseSqlServer(connStr));
            }
        }

        private string GetConnectionString()
        {
            string dbName;

            if (Environment.IsDevelopment())
            {
                dbName = "AuthenticationDB_Local";
            }
            else
            {
                dbName = "AuthenticationDB";
            }

            return Configuration.GetConnectionString(dbName);
        }
    }
}
