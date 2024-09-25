using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();

            RuleFor(x => x.AccesToken).NotEmpty();
        }
    }
}
