using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;
using PlannerApp.Interfaces;
using System;
using PlannerApp.Shared.Models.Configurations;
using PlannerApp.Brokers.Authentication;
using Blazored.LocalStorage;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using FluentValidation.AspNetCore;

namespace PlannerApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            var plannerAppConfiguration = builder.Configuration.GetSection("PlannerAppConfiguration") as PlannerAppConfiguration;
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddHttpClient<IPlannerAppService>("PlannerAPI",client => client.BaseAddress = new Uri(plannerAppConfiguration.BaseUrl))
                            .AddHttpMessageHandler<AuthorizationMessageHandler>();
            builder.Services.AddTransient<AuthorizationMessageHandler>();
            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("PlannerAPI"));
            builder.Services.AddMudServices();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddFluentValidation();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
            await builder.Build().RunAsync();
        }
    }
}
