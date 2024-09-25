﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using onion.Application.Interface.ITokenService;
using onion.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace onion.Infrastructure.Tokens
{

    public class TokenService : ITokenService
    {
        private readonly UserManager<User> userManager;
        private readonly TokenSettings tokenSettings;

        public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
        {
            tokenSettings = options.Value;
            this.userManager = userManager;
        }
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), //Token kimliğini olustururuz
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()), // Kullanıcı kimliğini token'a tanımlarız.
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(tokenSettings.TokenValidityInMunitues),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            await userManager.AddClaimsAsync(user, claims);

            return token;

        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }

        public ClaimsPrincipal? GetPrincipalFromExpiredlToken(string? token)
        {
            TokenValidationParameters tokenValidationParamaters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret)),
                ValidateLifetime = false,

            };

            JwtSecurityTokenHandler tokenHandler = new();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParamaters, out SecurityToken securityToken);
            if(securityToken is not JwtSecurityToken jwtSecurityToken 
                || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token Bulunamadı.");
            }


            return principal;
        }
    }
}
