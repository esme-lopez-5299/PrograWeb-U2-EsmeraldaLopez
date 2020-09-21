using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Practica3_Presidentes.Models
{
    public partial class presidentesContext : DbContext
    {
        public presidentesContext()
        {
        }

        public presidentesContext(DbContextOptions<presidentesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estadorepublica> Estadorepublica { get; set; }
        public virtual DbSet<Partidopolitico> Partidopolitico { get; set; }
        public virtual DbSet<Presidente> Presidente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=presidentes", x => x.ServerVersion("5.7.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estadorepublica>(entity =>
            {
                entity.ToTable("estadorepublica");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Partidopolitico>(entity =>
            {
                entity.ToTable("partidopolitico");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Presidente>(entity =>
            {
                entity.ToTable("presidente");

                entity.HasIndex(e => e.IdEstadoRepublica)
                    .HasName("IdEstadoRepublica_idx");

                entity.HasIndex(e => e.IdPartidoPolitico)
                    .HasName("IdPartidoPolitico_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Biografia)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CiudadNacimiento)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FechaFallecimiento).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdEstadoRepublica).HasColumnType("int(11)");

                entity.Property(e => e.IdPartidoPolitico).HasColumnType("int(11)");

                entity.Property(e => e.InicioGobierno).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ocupacion)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TerminoGobierno).HasColumnType("date");

                entity.HasOne(d => d.IdEstadoRepublicaNavigation)
                    .WithMany(p => p.Presidente)
                    .HasForeignKey(d => d.IdEstadoRepublica)
                    .HasConstraintName("IdEstadoRepublica");

                entity.HasOne(d => d.IdPartidoPoliticoNavigation)
                    .WithMany(p => p.Presidente)
                    .HasForeignKey(d => d.IdPartidoPolitico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdPartidoPolitico");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
