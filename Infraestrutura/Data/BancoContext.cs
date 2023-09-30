using Microsoft.EntityFrameworkCore;
using SagitarioRH.Models;
using SagitarioRhApi.Domain.Models;
using SagitarioRHDesktop.Models;
using System.Collections.Generic;

namespace SagitarioRhApi.Infraestrutura.Data
{
  public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<GerenteModel> gerente { get; set; }
        public DbSet<FuncionarioModel> funcionarios { get; set; }
        public DbSet<AdministradorModel> administradores { get; set; }
        public DbSet<EmpresaModel> empresas { get; set; }
        public DbSet<FolhaPgtoModel> folhaPgto { get; set; }
        public DbSet<ImpostoRendaModel> cadImpRenda { get; set; }
        public DbSet<ImpostoINSSModel> cadINSS { get; set; }

    }
}

