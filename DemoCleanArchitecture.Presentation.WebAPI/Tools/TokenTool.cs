using DemoCleanArchitecture.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoCleanArchitecture.Presentation.WebAPI.Tools
{
    public sealed class TokenTool
    {
        private readonly IConfiguration _configuration;
        public TokenTool(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public class Data
        {
            public long Id { get; set; }
            public MemberRoleEnum Role { get; set; }
        }
        public string Generate(Data data)
        {
            Claim[] claims = [
                new Claim("The Response","42"),
                new Claim(ClaimTypes.NameIdentifier, data.Id.ToString()),
                new Claim(ClaimTypes.Role, data.Role.ToString())
            ];

            byte[] key = Encoding.UTF8.GetBytes(_configuration["Token:Secret"]!);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha512);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: DateTime.UtcNow.AddHours(_configuration.GetValue<double>("Token:ExpiresMinute")),
                claims: claims,
                signingCredentials: signingCredentials
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
