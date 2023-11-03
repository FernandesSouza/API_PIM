using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SagitarioRhApi.Domain.DTOs;
using SagitarioRhApi.Domain.Models;
using SagitarioRhApi.Infraestrutura.Data;
using SagitarioRhApi.Infraestrutura.Interfaces;

namespace SagitarioRhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly BancoContext _context;
        private readonly IMobile _mobile;
        private readonly IMapper _mapper;


        public MobileController(BancoContext context, IMobile mobile, IMapper mapper)
        {
            _context = context;
            _mobile = mobile;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("LoginMobile")]
        public async Task<IActionResult> LoginFuncionarioMobile(FuncionarioLoginModel loginModel)
        {
            var funcionario =  await _context.funcionarios.SingleOrDefaultAsync(a => a.usuario == loginModel.usuario && a.senha == loginModel.senha);

            if(funcionario == null) { return BadRequest(); }
            else { return Ok(funcionario); }
                
        }

        [HttpGet]
        [Route("MobileHolerite")]
        public async Task<IActionResult> PesquisarHoleriteMobile(string cpf, DateTime data)
        {
            try
            {
                var holerite = await _mobile.ConsultaHolerite(cpf, data);

                if (holerite == null) { return NotFound(); }
                else
                {
                    var holeriteDTO = _mapper.Map<FolhaPagamentoDTO>(holerite);
                    return Ok(holeriteDTO);
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }
}
