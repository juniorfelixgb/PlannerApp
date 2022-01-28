// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using Microsoft.Extensions.DependencyInjection;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Client.Services.Services;

namespace PlannerApp.Client.Services.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services)
        {
            return services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
