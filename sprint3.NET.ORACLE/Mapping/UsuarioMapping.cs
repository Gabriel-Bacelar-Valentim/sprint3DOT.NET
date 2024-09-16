using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using sprint3.NET.Database.Models;

namespace sprint3.NET.Database.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_Usuarios_sprint3");

            builder.HasKey(u => u.Usuario_Id);

            builder.Property(u => u.NomeUsuario)
                .HasMaxLength(50);

            builder.Property(u => u.Senha)
                .HasMaxLength(50);

            builder.Property(u => u.NomeCompleto)
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(100);

            builder.Property(u => u.DataCriacao);

            builder.HasOne(u => u.Agricultor)
                .WithOne(a => a.Usuario)
                .HasForeignKey<Agricultor>(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
