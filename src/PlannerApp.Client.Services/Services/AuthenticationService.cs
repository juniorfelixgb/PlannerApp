// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        public AuthenticationService(HttpClient client)
        {
            _client = client;
        }
        public async Task<Response> RegisterUserAsync(RegisterRequest model)
        {
            var response = await _client.PostAsJsonAsync("/api/v2/auth/register", model);
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                throw new ApiException(errorResponse, errorResponse.StatusCode);
            }
            return await response.Content.ReadFromJsonAsync<Response>();
        }
    }
}
