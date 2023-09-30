using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SagitarioRH.Models
{

    [Table("administradores")]
    public class AdministradorModel
    {
        [Key]
        public int? idusuario { get; set; }
        public string? nome { get; set; }
        public string? sobrenome { get; set; }
        public string? usuario { get; set; }
        public string? senha { get; set; }





    }
}
