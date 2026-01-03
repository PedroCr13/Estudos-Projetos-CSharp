using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Api.Models.Entities.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Edicao)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.NumeroPagina)
                .IsRequired();

            builder.Property(e => e.Preco)
                .HasPrecision(18, 2);

            builder.Property(e => e.Editora)
                .HasMaxLength(150);

            builder.Property(e => e.SiteLivro)
                .HasColumnType("longtext");

            builder.Property(e => e.EmailAutor)
                .HasMaxLength(200);
        }
    }
}
