using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Domains
{

    [Table("Usuario")]
    [Index(nameof(EmailUsuario), IsUnique = true)]
    public class Usuario
    {
        [Key]

        public Guid Usuarioid { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome e obrigatorio")]
        public string? NomeUsuario { get;set; }

        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? EmailUsuario { get; set; }


        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(60, MinimumLength  = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres")]
        public string? SenhaUsuario { get; set; }



        [Required(ErrorMessage = "Tipo de Usuario obrigatorio")]
        public Guid TipoDeUsuarioid { get; set; }

        [ForeignKey("TipoDeUsuarioid")]
        public TipoDeUsuario? TipoDeUsuario { get; set; }
        
    }
}
