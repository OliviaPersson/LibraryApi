using LibraryApi.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryApi.Services
{
    public class JWTTServiceManage : IJWTTokenService
    {
        private readonly IConfiguration _config;
        public JWTTServiceManage(IConfiguration configuration)
        {
            _config = configuration;
        }

        JWTTokens IJWTTokenService.Authenticate(User user)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );
            var subject = new ClaimsIdentity(new[]
            {
            //new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            //new Claim(JwtRegisteredClaimNames.Email, usr.Email),
            new Claim("firstName", user.FirstName),
            new Claim("lastName", user.LastName),
            new Claim("userName", user.UserName),

             });

            //var expires = DateTime.UtcNow.AddMinutes(10);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return new JWTTokens { Token = jwtToken };
        }
    }
}
