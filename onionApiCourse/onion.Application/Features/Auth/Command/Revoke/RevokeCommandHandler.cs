using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using onion.Application.Bases;
using onion.Application.Features.Auth.Rules;
using onion.Application.Interface.AutoMapper;
using onion.Application.Interface.UnitOfWorks;
using onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandAllHandler : BaseHandler, IRequestHandler<RevokeCommandAllRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public RevokeCommandAllHandler(UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommandAllRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            await authRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
