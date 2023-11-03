using SagitarioRH.Models;
using SagitarioRHDesktop.Models;

namespace SagitarioRhApi.Infraestrutura.Interfaces
{
    public interface IFuncionario
    {
        Task Cadastro(FuncionarioModel funcionario);
        Task<FuncionarioModel> ConsultarFuncionario(int matricula);

        Task<IEnumerable<FolhaPgtoModel>> Holerites();

    }
}
