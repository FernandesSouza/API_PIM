using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SagitarioRhApi.Domain.DTOs;
using SagitarioRhApi.Infraestrutura.Interfaces;
using SagitarioRhApi.Infraestrutura.Repositorios;
using SagitarioRHDesktop.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SagitarioRhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionario _repFun;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionario repFun, IMapper mapper)
        {
            _repFun = repFun;
            _mapper = mapper;
        }

        [Authorize(Roles = "Gerente")]
        [HttpPost]
        public async Task<IActionResult> Cadastro(FuncionarioModel funcionario)
        {
            try
            {
                await _repFun.Cadastro(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Gerente")]
        [HttpGet("{matricula}")]
        public async Task<IActionResult> ConsultarFuncionario(int matricula)
        {

            var funcionario = await _repFun.ConsultarFuncionario(matricula);

            var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionario);

            return Ok(funcionarioDTO);

        }
       
    }
}
