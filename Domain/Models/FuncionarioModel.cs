using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace SagitarioRHDesktop.Models
{
    [Table("funcionarios")]
    public class FuncionarioModel
    {
        [Key]
        public int matricula { get; set; }
        public int? idempresa { get; set; }
        public string? usuario { get; set; }
        public DateTime dtadmissao { get; set; }
        public string? rg { get; set; }
        public string? email { get; set; }
        public int? jornada { get; set; }
        public string? pis { get; set; }
        public decimal salario { get; set; }
        public string? cep { get; set; }
        public string? nome { get; set; }
        public string? funcao { get; set; }
        public decimal? adcinsalubridade { get; set; }
        public int? dependentes { get; set; }
        public decimal? valerefeicao { get; set; }
        public string? cpf { get; set; }
        public decimal? adcpericulosidade { get; set; }
        public string? telefone { get; set; }
        public decimal? plsaude { get; set; }
        public decimal? valetransp { get; set; }
        public string? senha { get; set; }
        public string? setor { get; set; }




    }
}
