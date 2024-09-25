using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public String FullName { get; set; }
        public String? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }



    }
}
