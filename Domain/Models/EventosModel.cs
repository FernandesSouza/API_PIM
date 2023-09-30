using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SagitarioRH.Models
{

    [Table("eventospgto")]
    public class EventosModel
    {
        [Key]

        public int? codevento { get; set; }
        public string? evento { get; set; }
        public string? tipopgto { get; set; }
    }
}
