using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using sprint3.NET.Database.Models;

namespace sprint3.NET.Database.Mapping
{
    public class FazendaMapping : IEntityTypeConfiguration<Fazenda>
    {
        public void Configure(EntityTypeBuilder<Fazenda> builder)
        {
            builder.ToTable("TB_Fazendas_sprint3");

            builder.HasKey(f => f.Fazenda_Id);

            builder.Property(f => f.Nome)
                .HasMaxLength(100);

            builder.Property(f => f.TamanhoHectares);

            builder.Property(f => f.Localizacao)
                .HasMaxLength(200);

            builder.HasOne(f => f.Agricultor)
                .WithMany(a => a.Fazendas)
                .HasForeignKey(f => f.AgricultorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Solos)
                .WithOne(s => s.Fazenda)
                .HasForeignKey(s => s.FazendaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Safras)
                .WithOne(sa => sa.Fazenda)
                .HasForeignKey(sa => sa.FazendaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
