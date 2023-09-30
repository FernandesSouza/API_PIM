using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SagitarioRH.Models
{
    [Table("folhapgto")]
    public class FolhaPgtoModel
    {
        [Key]

        public int? id { get; set; }
        public int? idempresa { get; set; }
        public int? codevento { get; set; }
        public int? matfuncionario { get; set; }
        public DateTime datapgto { get; set; }
        public decimal? valor { get; set; }
        public string? nome { get; set; }
        public string? funcao { get; set; }
        public string? setor { get; set; }
        public string? evento { get; set; }

       


    }

}

