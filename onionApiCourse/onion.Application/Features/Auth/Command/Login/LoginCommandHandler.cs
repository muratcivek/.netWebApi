using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly AuthRules authRules;
        private readonly ITokenService tokenService;

        public LoginCommandHandler(UserManager<User> userManager,IConfiguration configuration, AuthRules authRules,ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.authRules = authRules;
            this.tokenService = tokenService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalıd(user, checkPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);

            string refreshToken = tokenService.GenerateRefreshToken();

           _= int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int RefreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(RefreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };

        }
    }
}
