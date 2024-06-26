﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECommerce.WebApi.System.Models.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.WebApi.System.Services
{
    public class JwtTokenGeneratorService : IJwtTokenGeneratorService
    {
        public SecurityToken GenerateJwtToken(User user, IConfiguration configuration)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                // Add additional claims as needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtSettings:ExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtSettings:Issuer"],
                configuration["JwtSettings:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return token;
        }
    }
}
