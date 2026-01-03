
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Api.Models.Entities.Mappings
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.QuantidadeLivrosVendidos)
                .HasColumnName("QuantidadeLivrosVendido")
                .HasColumnType("int");

            builder.Property(e => e.ValorRecebido)
                .HasPrecision(18, 2);

            builder.Property(e => e.Observacao)
                .HasColumnType("longtext");
        }
    }
}
