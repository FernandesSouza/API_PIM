using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SagitarioRhApi.Domain.Models
{

    [Table("gerente")]
    public class GerenteModel
    {

        [Key]

        public int? idusuario { get; set; }
        public string? nome { get; set; }
        public string? sobrenome { get; set; }
        public string? usuario { get; set; }
        public string? senha { get; set; }
        public int? idempresa { get; set; }



    }
}
