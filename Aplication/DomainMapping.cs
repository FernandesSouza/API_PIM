using AutoMapper;
using SagitarioRH.Models;
using SagitarioRhApi.Domain.DTOs;
using SagitarioRHDesktop.Models;

namespace SagitarioRhApi.Aplication
{
    public class DomainMapping : Profile
    {


        public DomainMapping()
        {

            CreateMap<FuncionarioDTO, FuncionarioModel>();
            CreateMap<FuncionarioModel, FuncionarioDTO>();

            CreateMap<FolhaPagamentoDTO, FolhaPgtoModel>();
            CreateMap<FolhaPgtoModel, FolhaPagamentoDTO>();




        }
    }
}
