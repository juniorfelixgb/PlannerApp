// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using Microsoft.AspNetCore.Components;
using PlannerApp.Shared.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlannerApp.Components.Authentication
{
    public partial class LoginForm
    {
        [Inject] public HttpClient HttpClient { get; set; }
        
        private LoginRequest _loginRequest = new();

        private async Task LoginUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
