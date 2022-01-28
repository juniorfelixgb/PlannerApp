// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlannerApp
{
    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;
        public AuthorizationMessageHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (await _localStorage.ContainKeyAsync("access_token"))
            {
                var token = await _localStorage.GetItemAsStringAsync("access_token");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
