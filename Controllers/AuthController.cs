using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SagitarioRH.Models;
using SagitarioRhApi.Domain.DTOs;
using SagitarioRhApi.Domain.Models;
using SagitarioRhApi.Infraestrutura.Data;
using SagitarioRhApi.Infraestrutura.Interfaces;
using SagitarioRhApi.Services;
using SagitarioRHDesktop.Models;

namespace SagitarioRhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly BancoContext _context;

        public AuthController(BancoContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost]
        [Route("LoginFuncionario")]
        public async Task<ActionResult<dynamic>> AutenticarFuncionario(FuncionarioLoginModel loginModel)
        {
            var funcionario = await _context.funcionarios.FirstOrDefaultAsync(a => a.usuario == loginModel.usuario && a.senha == loginModel.senha);

            if (funcionario != null)
            {
                var token = _tokenService.GerarToken(funcionario);


                return Ok(new { Token = token, Funcionario = funcionario });
            }
            else {


                return BadRequest("Usuário ou senha inválidos");
                


            }

           
        }


        [HttpPost]
        [Route("LoginGerente")]
        public async Task<ActionResult<dynamic>> AutenticarGerente(GerenteLoginModel gerenteLogin)
        {

            var gerente = await _context.gerente.FirstOrDefaultAsync(b => b.usuario == gerenteLogin.usuario && b.senha == gerenteLogin.senha);

            if(gerente == null)
            {

                return BadRequest("Usuário ou senha inválidos");


            }

            var token =   _tokenService.GerarToken(gerente);


            return Ok(new { Token = token, Funcionario = gerente });




        }



    }
}
