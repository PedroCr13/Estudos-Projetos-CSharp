using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Api.Models.Entities.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(l => l.Edicao)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(l => l.NumeroPagina)
                .IsRequired();

            builder.Property(l => l.Preco)
                .HasPrecision(18, 2);

            builder.Property(l => l.SiteLivro)
                .HasColumnType("longtext");

            builder.Property(l => l.EmailAutor)
                .HasMaxLength(200);

            builder.HasOne(l => l.Editora)
                .WithMany(e => e.Livros)
                .HasForeignKey(l => l.Id_editora)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
