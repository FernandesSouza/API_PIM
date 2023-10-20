using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SagitarioRH.Models;
using SagitarioRhApi.Domain.DTOs;
using SagitarioRhApi.Infraestrutura.Interfaces;
using System.Data;

namespace SagitarioRhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoleriteController : ControllerBase
    {
        private readonly IHolerite _repFun;
        private readonly IMapper _mapper;

        public HoleriteController(IHolerite repFun, IMapper mapper)
        {
            _repFun = repFun;
            _mapper = mapper;
        }

        [HttpGet("{datapgto}")]
        [Authorize(Roles = "Funcionario")]
        public async Task<ActionResult> ObterFolhaPagamento(DateTime datapgto)
        {
            try
            {
                // Obter a matrícula do funcionário autenticado
                var matricula = ObterMatriculaDoUsuarioAutenticado();

                if (matricula == null)
                {
                    return BadRequest("Não foi possível obter a matrícula do usuário autenticado.");
                }

                // Chama a função PesquisaHolerite com a matrícula e a data de pagamento
                var holerite = await _repFun.PesquisaHolerite(matricula.Value, datapgto);

                if (holerite == null)
                {
                    return NotFound("Holerite não encontrado");
                }

                return Ok(holerite); // Retorna 200 com o holerite encontrado
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Retorna 500 se ocorrer um erro interno

            }
        }

        private int? ObterMatriculaDoUsuarioAutenticado()
        {
            var claimMatricula = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Matricula");

            if (claimMatricula != null && int.TryParse(claimMatricula.Value, out int matricula))
            {
                return matricula;
            }

            return null;
        }

        private int? ObterIdempresaGerenteAutenticado()
        {
            var claimIDempresa = HttpContext.User.Claims.FirstOrDefault(e => e.Type == "Idempresa");

                if(claimIDempresa != null && int.TryParse(claimIDempresa.Value, out int idempresa))
            {


                return idempresa;

            } else
            {

                return null;
                    
            }

        }

        [HttpGet("setor/{setor}")]
        [Authorize(Roles = "Gerente")]
       
        public async Task<ActionResult<IEnumerable<FolhaPgtoModel>>> ConsultarFolhaSetor(string setor)
        {
          
            try
            {
                var idempresa = ObterIdempresaGerenteAutenticado();


                var pagamento = await _repFun.FolhaPagamento(setor, idempresa!.Value);  

                if(pagamento == null)
                {

                    return NotFound();

                }
                var folhaDto = _mapper.Map<IEnumerable<FolhaPagamentoDTO>>(pagamento);

                return Ok(folhaDto);

            } catch(Exception ex)
            {


                return StatusCode(500, ex.Message);

            }


        }
       


    }
}


