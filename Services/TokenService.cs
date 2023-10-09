

using Microsoft.IdentityModel.Tokens;
using SagitarioRH.Models;
using SagitarioRhApi.Domain.DTOs;
using SagitarioRhApi.Domain.Models;
using SagitarioRhApi.Infraestrutura.Interfaces;
using SagitarioRHDesktop.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SagitarioRhApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _chave;

        public TokenService(IConfiguration config)
        {
            _chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["chaveSecreta"]!));
        }

        public string GerarToken(FuncionarioModel funcionario)
        {
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.NameId, funcionario.usuario!),
                new Claim(JwtRegisteredClaimNames.Sub, funcionario.senha!),
                new Claim(ClaimTypes.Role, "Funcionario"),
                new Claim("Matricula", funcionario.matricula.ToString())





            };

            var credenciais = new SigningCredentials(_chave, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {


                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
               
                SigningCredentials = credenciais,



            };



            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }

        public string GerarToken(GerenteModel gerente)
        {

            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.NameId, gerente.usuario!),
                new Claim(JwtRegisteredClaimNames.Sub, gerente.senha!),
                new Claim(ClaimTypes.Role, "Gerente"),
                new Claim("Idempresa", gerente.idempresa.ToString()!)





            };


            var credenciais = new SigningCredentials(_chave, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {


                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),

                SigningCredentials = credenciais,



            };



            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);



        }

    }
    
}     
