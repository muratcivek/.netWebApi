using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandAllRequest : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
