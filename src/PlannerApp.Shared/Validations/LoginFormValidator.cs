// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using FluentValidation;
using FluentValidation.Validators;
using PlannerApp.Shared.Request;

namespace PlannerApp.Shared.Validations
{
    public partial class LoginFormValidator : AbstractValidator<LoginRequest>
    {
        public LoginFormValidator()
        {
            RuleFor(v => v.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).NotEmpty().WithMessage("El email es requerido.");
            RuleFor(v => v.Password).MinimumLength(5).NotEmpty().WithMessage("La contraseña debe ser mayor a 3 digitos.");
        }
    }
}
