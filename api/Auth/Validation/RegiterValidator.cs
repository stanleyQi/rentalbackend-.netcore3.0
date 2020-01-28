using api.Auth.Dto;
using api.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Auth.Validation
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
      .WithMessage("Email is mandatory.");

            RuleFor(x => x.Password)
      .NotEmpty()
      .WithMessage("Password is mandatory.");

            RuleFor(x => x.Role).NotEmpty()
      .WithMessage("Role is mandatory.");
        }
    }
}
