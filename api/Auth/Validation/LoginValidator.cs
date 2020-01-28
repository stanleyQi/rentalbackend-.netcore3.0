using api.Auth.Dto;
using api.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Auth.Validation
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
      .WithMessage("Email is mandatory.");

            RuleFor(x => x.Password)
      .NotEmpty()
      .WithMessage("Password is mandatory.");
        }
    }
}
