using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SagitarioRhApi.Infraestrutura.Data;
using SagitarioRhApi.Infraestrutura.Interfaces;
using SagitarioRHDesktop.Models;
using System.Runtime.InteropServices;

namespace SagitarioRhApi.Infraestrutura.Repositorios
{
    public class RepFun : IFuncionario
    {

        private readonly BancoContext _context;
        private readonly IImpostoCalcular _impostoCalcular;

        public RepFun(BancoContext context, IImpostoCalcular impostoCalcular)
        {
            _context = context;
            _impostoCalcular = impostoCalcular;
        }

        public async Task Cadastro(FuncionarioModel funcionario)
        {

            var existe = await _context.funcionarios.AnyAsync(f => f.matricula == funcionario.matricula);

            if (!existe)
            {
                var novoFuncionario = await _context.funcionarios.AddAsync(funcionario);
                await _context.SaveChangesAsync();

                await _impostoCalcular.CalcularINSS(novoFuncionario.Entity);
                await _context.SaveChangesAsync();
            }

            else
            {

                throw new Exception("Tentativa de inserir um funcionário duplicado.");

            }

        }

        public async Task<FuncionarioModel> ConsultarFuncionario(int matricula)
        {

            return await _context.funcionarios.FirstAsync(f => f.matricula == matricula);


        }
    }
}
