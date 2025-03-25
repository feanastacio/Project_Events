using Api_Event.Domains;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Context
{
    public class Event_Context : DbContext
    {
        public Event_Context() { }

        public Event_Context(DbContextOptions<Event_Context> options) : base(options)
        { }

        public DbSet <Usuario> Usuario { get; set; }
        public DbSet <Evento> Evento { get; set; }
        public DbSet <TipoDeEvento> TipoDeEventos { get; set; }
        public DbSet<TipoDeUsuario> TipoDeUsuario { get; set; }
        public DbSet <Instituicao> Instituicao { get; set; }
        public DbSet <ComentarioEvento> ComentarioEvento { get; set; }

        public DbSet <Presenca> Presenca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-S3CGL03\\SQLEXPRESS; Database=ProjectEvents; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true; ");

            }

        }






    }
}
