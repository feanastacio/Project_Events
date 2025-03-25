﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Event.Domains
{

    [Table("Evento")]
    public class Evento
    {
        [Key]

        public Guid Eventoid { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome do evento e obrigatorio")]
        public string? NomeEvento { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento e obrigatoria")]
        public DateTime DataEvento { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do evento é obrigatória")]
        public string? DescricaoEvento { get; set; }




        [Required(ErrorMessage = "Tipo de Evento obrigatorio")]
        public Guid TipoDeEventoid { get; set; }

        [ForeignKey("TipoDeEventoid")]
        public TipoDeEvento? TipoDeEvento { get; set; }




        [Required(ErrorMessage = "Campo obrigatorio")]
        public Guid Instituicaoid { get; set; }

        [ForeignKey("Instituicaoid")]
        public Instituicao? instituicao { get; set; }

        
        
        
        
        public Presenca? Presenca { get; set; }

    }
}
