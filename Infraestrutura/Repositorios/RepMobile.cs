using Microsoft.EntityFrameworkCore;
using SagitarioRH.Models;
using SagitarioRhApi.Infraestrutura.Data;
using SagitarioRhApi.Infraestrutura.Interfaces;

namespace SagitarioRhApi.Infraestrutura.Repositorios
{
    public class RepMobile : IMobile
    {
        private readonly BancoContext _context;

        public RepMobile(BancoContext context)
        {
            _context = context;
        }

        public Task<FolhaPgtoModel?> ConsultaHolerite(string cpf, DateTime data)
        {

            var folha = _context.folhaPgto.SingleOrDefaultAsync(c => c.cpf == cpf && c.datapgto == data);
            if(folha == null) { throw new Exception("Ocorreu um problema, consulte a administração"); }
          
            else
            {
                return folha;
              

            }

        }
    }
}
