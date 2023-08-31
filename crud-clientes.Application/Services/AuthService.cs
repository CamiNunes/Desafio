using crud_clientes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Application.Services
{
    public class AuthService 
    {
        private readonly string _secretKey = "A8CB5DDC-0E2A-4DC5-A298-2F175F9B9311"; // Defina sua chave secreta para JWT

        //public string GerarJwtToken(string email, Guid usuarioId)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_secretKey);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
        //            new Claim(ClaimTypes.Name, email)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
