using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Api.Models.Entities.Mappings
{
    public class EditoraMapping : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.ToTable("Editoras");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasColumnType("longtext")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Endereco)
                .HasColumnType("longtext")
                .HasMaxLength(200);

            builder.Property(e => e.Telefone)
                .HasColumnType("longtext")
                .HasMaxLength(14);

            builder.Property(e => e.Site)
                .HasColumnType("longtext");

            builder.Property(e => e.Email)
                .HasColumnType("longtext");

            builder.Property(e => e.Observacao)
                .HasColumnType("longtext");

            builder.HasMany(e => e.Livros)
                .WithOne(l => l.Editora)
                .HasForeignKey(l => l.Id_editora)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
