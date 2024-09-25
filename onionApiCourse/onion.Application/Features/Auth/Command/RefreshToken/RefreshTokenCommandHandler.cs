using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using onion.Application.Bases;
using onion.Application.Features.Auth.Rules;
using onion.Application.Interface.AutoMapper;
using onion.Application.Interface.ITokenService;
using onion.Application.Interface.UnitOfWorks;
using onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler :BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public RefreshTokenCommandHandler(IMapper mapper,AuthRules authRules, UserManager<User> userManager, ITokenService tokenService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {

           var principal = tokenService.GetPrincipalFromExpiredlToken(request.AccesToken);
           string email = principal.FindFirstValue(ClaimTypes.Email);

           var user = await userManager.FindByNameAsync(email);
           var roles = await userManager.GetRolesAsync(user);

            await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccesToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };
        }
    }
}
