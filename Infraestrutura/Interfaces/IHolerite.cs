using SagitarioRH.Models;

namespace SagitarioRhApi.Infraestrutura.Interfaces
{
    public interface IHolerite
    {
        Task<FolhaPgtoModel> PesquisaHolerite(int matricula, DateTime datapgto);

        Task<IEnumerable<FolhaPgtoModel>> FolhaPagamento(string setor, int idempresa);

    }
}
