using SagitarioRH.Models;
using SagitarioRHDesktop.Models;


namespace SagitarioRhApi.Infraestrutura.Interfaces
{
    public interface IImpostoCalcular
    {
        Task<IEnumerable<FolhaPgtoModel>> CalcularINSS(FuncionarioModel model);

    }
}
