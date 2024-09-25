using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.Login
{
    public class LoginCommandResponse
    {
        public String Token { get; set; }
        public String RefreshToken { get; set; }
        public DateTime Expiration { get; set; }

    }
}
