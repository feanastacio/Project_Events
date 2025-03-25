﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Domains
{
    [Table("ComentarioEvento")]
    [Index(nameof(Exibe), IsUnique = true)]

    public class ComentarioEvento
    {
        [Key]
        public  Guid ComentarioEventoid { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string? Comentario { get; set; }


        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A resposta é necessária")]
        public bool? Exibe { get; set; }




        [Required(ErrorMessage = "Usuario obrigatorio")]
        public Guid Usuarioid { get; set; }

        [ForeignKey("Usuarioid")]
        public Usuario? Usuario { get; set; }




        [Required(ErrorMessage = "Evento obrigatorio")]
        public Guid Eventoid { get; set; }

        [ForeignKey("Eventoid")]
        public Evento? Evento { get; set; }
    }
}
