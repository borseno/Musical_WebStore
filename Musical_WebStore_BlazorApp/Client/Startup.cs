using Blazored.Localisation;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Musical_WebStore_BlazorApp.Services;

namespace Musical_WebStore_BlazorApp.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<UserService, UserService>();
            services.AddScoped<CommentService, CommentService>();
            services.AddScoped<StarService, StarService>();
            services.AddScoped<ITestEnrollService, TestEnrollService>();
            services.AddScoped<ITestingInfoService, TestingInfoService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseBlazoredLocalisation();
            app.AddComponent<App>("app");
        }
    }
}
