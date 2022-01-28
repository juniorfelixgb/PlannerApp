// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PlannerApp.Components.Authentication
{
    public partial class LoginForm
    {
        private LoginRequest _loginRequest = new();
        private bool _isBusy = false;
        private string _errorMessage = string.Empty;
        private async Task LoginUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;
            var response = await HttpClient.PostAsJsonAsync("/api/v2/auth/login", _loginRequest);
            if (!response.IsSuccessStatusCode)
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                _errorMessage = errorResult.Message;
                _isBusy = false;
                return;
            }
            var result = await response.Content.ReadFromJsonAsync<Response<LoginResult>>();
            if (result.IsSuccess)
            {
                await LocalStorage.SetItemAsStringAsync("access_token", result.Value.Token);
                await LocalStorage.SetItemAsync<DateTime>("expiry_date", result.Value.ExpiryDate);
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                NavigationManager.NavigateTo("/");
            }
        }

        [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public ILocalStorageService LocalStorage { get; set; }
    }
}
