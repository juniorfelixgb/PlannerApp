// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlannerApp.Brokers.Authentication
{
    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _storage;

        public AuthorizationMessageHandler(
            ILocalStorageService storage)
        {
            _storage = storage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (await _storage.ContainKeyAsync("access_token"))
            {
                var token = await _storage.GetItemAsStringAsync("access_token", cancellationToken);
                request.Headers.Authorization = new("Bearer", token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
