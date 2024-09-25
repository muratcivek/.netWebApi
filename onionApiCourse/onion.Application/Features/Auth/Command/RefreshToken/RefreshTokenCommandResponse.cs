using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
