using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai.MinhaVoz.Dominio.Entidades;

namespace Senai.MinhaVoz.Infra.Data.Domains
{
    public partial class MinhaVozContext : DbContext
    {
        public MinhaVozContext()
        {
        }

        public MinhaVozContext(DbContextOptions<MinhaVozContext> options)
            : base(options)
        {
        }	

        public virtual DbSet<Chamado> Chamado { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=48975462811; Initial Catalog= MinhaVozManha; user id= sa; pwd= S#nai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.HasIndex(e => e.Telefone)
                    .HasName("UQ__Chamado__D6F1694F47D21FA5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Assunto)
                    .IsRequired()
                    .HasColumnName("ASSUNTO")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("Tipo_Usuario");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Tipo_Usu__E2AB1FF4FA4EE604")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasColumnName("NOME_TIPO_USUARIO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.NomeTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasPrincipalKey(p => p.Nome)
                    .HasForeignKey(d => d.NomeTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__NOME_TI__7E37BEF6");
            });
        }
    }
}
