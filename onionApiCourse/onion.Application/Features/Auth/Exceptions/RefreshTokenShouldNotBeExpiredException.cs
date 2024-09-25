using onion.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sonlanmıştır. Lütfen tekrar giriş yapınız.") { }
    }
}
