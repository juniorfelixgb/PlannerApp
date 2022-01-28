using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Response> RegisterUserAsync(RegisterRequest model);
    }
}
