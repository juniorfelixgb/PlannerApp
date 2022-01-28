// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using FluentValidation;
using PlannerApp.Shared.Models;

namespace PlannerApp.Shared.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not a valid email address");

            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(25).WithMessage("First name must be less than 25 characters");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(25).WithMessage("Last name must be less than 25 characters");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(5).WithMessage("Password must at least 5 characters");

            RuleFor(r => r.ConfirmPassword)
                .Equal(r => r.Password).WithMessage("Confirm password doesn't match the password");
        }
    }
}
