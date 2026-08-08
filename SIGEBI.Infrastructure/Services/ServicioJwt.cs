using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIGEBI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIGEBI.Infrastructure.Services
{
    public class ServicioJwt : IServicioJwt
    {
        private readonly IConfiguration _config;

        public ServicioJwt(IConfiguration config)
        {
            _config = config;
        }

        public string GenerarToken(int idUsuario, string email, string rol, string nombre, string? matricula, string? numeroEmpleado)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("Falta la SecretKey en appsettings.json");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, idUsuario.ToString()),
                new Claim(ClaimTypes.Email, email ?? "sin-correo@itla.edu.do"),
                new Claim(ClaimTypes.Role, rol),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, nombre)
            };

            if (!string.IsNullOrEmpty(matricula))
            {
                claims.Add(new Claim("Matricula", matricula));
            }

            if (!string.IsNullOrEmpty(numeroEmpleado))
            {
                claims.Add(new Claim("NumeroEmpleado", numeroEmpleado));
            }

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationInMinutes"])),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}