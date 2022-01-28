// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

namespace PlannerApp.Shared.Models
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
