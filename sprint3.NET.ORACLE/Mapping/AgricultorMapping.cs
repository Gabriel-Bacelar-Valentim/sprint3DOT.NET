
using Microsoft.EntityFrameworkCore;
using sprint3.NET.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace sprint3.NET.Database.Mapping
{
    public class AgricultorMapping : IEntityTypeConfiguration<Agricultor>
    {
        public void Configure(EntityTypeBuilder<Agricultor> builder)
        {
            builder.ToTable("TB_Agricultores_sprint3");

            builder.HasKey(a => a.Agricultor_Id);

            builder.Property(a => a.Nome)
                .HasMaxLength(100);

            builder.Property(a => a.Cidade)
                .HasMaxLength(50);

            builder.Property(a => a.Estado)
                .HasMaxLength(50);

            builder.Property(a => a.Telefone)
                .HasMaxLength(15);

            builder.Property(a => a.Email)
                .HasMaxLength(100);

            builder.HasOne(a => a.Usuario)
                .WithOne(u => u.Agricultor)
                .HasForeignKey<Agricultor>(a => a.UsuarioId);
        }
    }
}
