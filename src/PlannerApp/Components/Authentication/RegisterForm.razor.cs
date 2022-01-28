// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using Microsoft.AspNetCore.Components;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;
using System;
using System.Threading.Tasks;

namespace PlannerApp.Components.Authentication
{
    public partial class RegisterForm
    {
        private RegisterRequest _registerRequest = new();
        private bool _isBusy = false;
        private string _errorMessage = string.Empty;
        private async Task RegisterUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;
            try
            {
                var response = await AuthenticationService.RegisterUserAsync(_registerRequest);
                if (!response.IsSuccess)
                {
                    _errorMessage = response.Message;
                    _isBusy = false;
                    return;
                }
                NavigationManager.NavigateTo("/authentication/login");
            }
            catch (ApiException ex)
            {
                _errorMessage = ex.ErrorResponse.Message;
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
        }

        private void RedirectToLogin()
        {
            NavigationManager.NavigateTo("/authentication/login");
        }

        [Inject] public IAuthenticationService AuthenticationService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
    }
}
