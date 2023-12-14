using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Atividade_para_emprego.Auth
{
    public class TokenService 
    {
        public string GenerateToken(string id)
        {
            var key = Encoding.UTF8.GetBytes("gabrielcardosogirarde12345678913465555555dddddddddddddddddddddddddddddddddddddddd5555");

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256
            );

            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Sub, id),
                new Claim(JwtRegisteredClaimNames.Iss, "gabapi"),
                new Claim(ClaimTypes.Role, "COMMON")
            };
            var securityToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials,
                claims: claims
            );

            var provider = new JwtSecurityTokenHandler();
            
            return provider.WriteToken(securityToken);
        }
    }
}