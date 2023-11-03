using SagitarioRH.Models;

namespace SagitarioRhApi.Infraestrutura.Interfaces
{
    public interface IMobile
    {


        Task<FolhaPgtoModel?> ConsultaHolerite(string cpf, DateTime data);
        
    }
}
