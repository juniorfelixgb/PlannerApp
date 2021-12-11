// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Request
{
    public partial class LoginForm : AbstractValidator<LoginRequest>
    {
        public LoginForm()
        {
            RuleFor(v => v.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                                           .NotEmpty()
                                           .WithMessage("El email es requerido.");
            RuleFor(v => v.Password).MinimumLength(5)
                                              .NotEmpty()
                                              .WithMessage("La contraseña debe ser mayor a 3 digitos.");
        }
    }
}
