using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SagitarioRH.Models
{
    [Table("cadimprenda")]
    public class ImpostoRendaModel
    {
        [Key]

        public int id { get; set; }
        public decimal vlinicial { get; set; }
        public decimal vlfinal { get; set; }
        public decimal aliquota { get; set; }
        public decimal vldeducao { get; set; }
    }
}
