using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prj_ConsultaNotas_SO_DG.Entities;

namespace Prj_ConsultaNotas_SO_DG.Data
{
    public class Prj_ConsultaNotas_SO_DGContext : DbContext
    {
        public Prj_ConsultaNotas_SO_DGContext(DbContextOptions<Prj_ConsultaNotas_SO_DGContext> options)
            : base(options)
        {
        }

        public DbSet<Prj_ConsultaNotas_SO_DG.Entities.Asignatura> Asignatura { get; set; }

        public DbSet<Prj_ConsultaNotas_SO_DG.Entities.Estudiante> Estudiante { get; set; }

        public DbSet<Prj_ConsultaNotas_SO_DG.Entities.Docente> Docente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notas>()
                .HasOne(d => d.Docente)
                .WithMany(p => p.Notas)
                .HasForeignKey(d => d.Docente_Id);

            modelBuilder.Entity<Notas>()
                .HasOne(d => d.Estudiante)
                .WithMany(p => p.Notas)
                .HasForeignKey(d => d.Estudiante_Id);
            modelBuilder.Entity<Notas>()
            .HasOne(d => d.Asignatura)
            .WithMany(p => p.Notas)
            .HasForeignKey(d => d.Asignatura_Id);
        }

        public DbSet<Prj_ConsultaNotas_SO_DG.Entities.Notas> Notas { get; set; }
    }
}
