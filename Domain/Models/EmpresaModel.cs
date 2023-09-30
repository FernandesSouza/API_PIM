using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SagitarioRH.Models
{
    [Table("empresas")]
    public class EmpresaModel
    {
        [Key]
        public int idempresa { get; set; }
        public string? telefone { get; set; }
        public string? razaosocial { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public string? usuario { get; set; }
        public string? nmfantasia { get; set; }
        public string? titularemp { get; set; }
        public string? cnpj { get; set; }
    }
}
