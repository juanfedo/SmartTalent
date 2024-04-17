using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructura.Autenticacion
{
    public class JWTHandler: IJWTHandler
    {
        private readonly string? secretKey;

        public JWTHandler(string key)
        {
            secretKey = key;
        }

        public string CreateToken(string login, bool esAdministrador)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey ?? string.Empty);
            var claims = new ClaimsIdentity();

            var claimsList = new List<Claim> { 
                new(ClaimTypes.Name, login),
                new("EsAdministrador", esAdministrador.ToString())
            };

            claims.AddClaims(claimsList);

            var tokkenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokkenDescriptor);

            return tokenHandler.WriteToken(tokenConfig);
        }
    }
}
