﻿using Microsoft.EntityFrameworkCore;
using webapi.event_.Domains;

namespace webapi.event_.Contexts
{
    public class Context : DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<TiposEventos> TiposEventos { get; set; }

        public DbSet<Eventos> Eventos { get; set; }

        public DbSet<ComentariosEventos> ComentariosEventos { get; set; }

        public DbSet<Instituicoes> Instituicoes { get; set; }

        public DbSet<PresencasEventos> PresencasEventos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-S3CGL03\\SQLEXPRESS; Database = Event; User id = sa; Pwd = Senai@134; trustServerCertificate=true;");
            }
        }
    }
}