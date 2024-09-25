using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandAllValidator :AbstractValidator<RevokeCommandAllRequest>
    {
        public RevokeCommandAllValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
