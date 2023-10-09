using Microsoft.EntityFrameworkCore;
using SagitarioRH.Models;
using SagitarioRhApi.Infraestrutura.Data;
using SagitarioRhApi.Infraestrutura.Interfaces;

namespace SagitarioRhApi.Infraestrutura.Repositorios
{
    public class Holerite : IHolerite
    {
        private readonly BancoContext _context;

        public Holerite(BancoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FolhaPgtoModel>> FolhaPagamento(string setor, int idempresa)
        {
            var folha = await _context.folhaPgto.Where(f => f.setor!.Contains(setor) && f.idempresa == idempresa).ToListAsync();
            
            if(folha == null)
            {
                throw new InvalidOperationException("Ocorreu um problema, consulte a administração");

            }

            return folha;
        }

        public async Task<FolhaPgtoModel> PesquisaHolerite(int matricula, DateTime datapgto)
        {
            var holerite = await _context.folhaPgto.FirstOrDefaultAsync(h => h.matfuncionario == matricula && h.datapgto == datapgto);


            if (holerite == null)
            {
                throw new InvalidOperationException("Holerite não encontrado"); // Ou você pode retornar null ou outro valor apropriado
            }

            return holerite;



        }
    }
}
