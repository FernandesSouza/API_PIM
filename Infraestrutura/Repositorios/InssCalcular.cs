using SagitarioRhApi.Infraestrutura.Data;
using SagitarioRhApi.Infraestrutura.Interfaces;
using SagitarioRHDesktop.Models;
using Microsoft.EntityFrameworkCore;
using SagitarioRH.Models;

namespace SagitarioRhApi.Infraestrutura.Repositorios
{
    public class InssCalcular : IImpostoCalcular
    {
        private readonly BancoContext _context;

        public InssCalcular(BancoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FolhaPgtoModel>> CalcularINSS(FuncionarioModel model)
        {
            decimal aliquota1 = 0.08m;
            decimal aliquota2 = 0.09m;
            decimal aliquota3 = 0.12m;
            decimal aliquota4 = 0.14m;
            decimal valor1 = 1320.00m;
            decimal valor2 = 2571.29m;
            decimal valor3 = 3856.94m;
            decimal SalarioINSS;

            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var query = _context.funcionarios
                .Where(e => !_context.folhaPgto.Any(f => f.datapgto >= firstDayOfMonth && f.matfuncionario == e.matricula))
                .ToList();


            List<FolhaPgtoModel> resultado = new List<FolhaPgtoModel>();

            foreach (var item in query)
            {


                if (item != null)
                {
                    FolhaPgtoModel folhaPagamento = new FolhaPgtoModel();

                    if (item.salario <= valor1)
                    {
                        SalarioINSS = item.salario * aliquota1;
                    }
                    else if (item.salario <= valor2)
                    {
                        SalarioINSS = item.salario * aliquota2;
                    }
                    else if (item.salario <= valor3)
                    {
                        SalarioINSS = item.salario * aliquota3;
                    }
                    else
                    {
                        SalarioINSS = item.salario * aliquota4;
                    }

                    folhaPagamento.nome = item.nome;
                    folhaPagamento.funcao = item.funcao;
                    folhaPagamento.valor = item.salario - SalarioINSS;
                    folhaPagamento.matfuncionario = item.matricula;
                    folhaPagamento.idempresa = item.idempresa;
                    folhaPagamento.datapgto = DateTime.Now;
                    folhaPagamento.setor = item.setor;
                    


                    resultado.Add(folhaPagamento);

                    Console.WriteLine($"Valor do INSS calculado: {folhaPagamento.valor}");


                }

                


            }

            await _context.AddRangeAsync(resultado);
            await _context.SaveChangesAsync();

            return resultado;

        }
    }
}
