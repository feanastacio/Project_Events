using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Domains
{
    [Table("Instituicoes")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicoes
    {
        [Key]
        public Guid Instituicaoid { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "Cnpj obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome Fantasia obrigatório!")]
        public string? NomeFantasia { get; set; }

    }
}
