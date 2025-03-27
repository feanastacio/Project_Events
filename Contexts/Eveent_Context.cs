using api_filmes_senai.Domains;
using Eveent_.Domains;
using Microsoft.EntityFrameworkCore;

namespace Eveent_.Context
{
    public class Eveent_Context : DbContext
    {
            public Eveent_Context()
            {
            }
            public Eveent_Context(DbContextOptions<Eveent_Context> options) : base(options)
            {
            }

            public DbSet<Usuarios> Usuarios { get; set; }
            public DbSet<Eventos> Eventos { get; set; }
            public DbSet<Presenca> Presenca { get; set; }
            public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
            public DbSet<Instituicoes> Instituicoes { get; set; }
            public DbSet<TiposEventos> TiposEventos { get; set; }
            public DbSet<TiposUsuarios> TiposUsuarios { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Server = DESKTOP-S3CGL03\\SQLEXPRESS; Database = ProjectEvent; User id = sa; Pwd = Senai@134; trustServerCertificate=true;");

                }
            }

        }
    }

