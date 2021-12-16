using Microsoft.AspNetCore.Components;
using PlannerApp.Shared.Request;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlannerApp.Components.Authentication
{
    public partial class LoginForm : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        private LoginRequest model = new();
        public LoginForm()
        {

        }
        public Task LoginUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
