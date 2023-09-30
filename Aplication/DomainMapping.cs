using AutoMapper;
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
            
        }
    }
}
