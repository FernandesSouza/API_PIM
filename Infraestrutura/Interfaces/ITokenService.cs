

using SagitarioRH.Models;
using SagitarioRhApi.Domain.Models;
using SagitarioRHDesktop.Models;

namespace SagitarioRhApi.Infraestrutura.Interfaces
{
    public interface ITokenService
    {
         string GerarToken(FuncionarioModel funcionario);

         string GerarToken(GerenteModel gerente);

    }
}
