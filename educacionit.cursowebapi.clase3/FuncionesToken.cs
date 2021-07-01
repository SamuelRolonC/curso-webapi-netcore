using educacionit.cursowebapi.clase3.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace educacionit.cursowebapi.clase3
{
    public static class FuncionesToken
    {
        public static Usuario AutenticarUsuario(Usuario usuario, NorthwindContext context)
        {
            var usuarioDb = new Usuario();

            usuarioDb = (from u in context.Usuarios
                         where u.Usuario1 == usuario.Usuario1 && u.Password == usuario.Password
                         select u).SingleOrDefault();

            return usuarioDb;
        }

        public static string GenerarToken(Usuario usuario, IConfiguration config)
        {
            // Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:ClaveSecreta"]));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            // Claims
            var nombre = usuario.Nombre ?? "";
            var apellido = usuario.Apellido ?? "";
            var email = usuario.Email ?? "";

            var _claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId,usuario.Id.ToString()),
                new Claim("nombre", nombre),
                new Claim("apellido", apellido),
                new Claim(JwtRegisteredClaimNames.Email, email)
            };

            // Payload
            var _payload = new JwtPayload(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: _claims, notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30));

            // Token
            var _token = new JwtSecurityToken(_header, _payload);

            return new JwtSecurityTokenHandler().WriteToken(_token);
        }
    }
}
