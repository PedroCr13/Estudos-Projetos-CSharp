using Biblioteca.Api.Models.Entities;
using Biblioteca.Api.Models.Entities.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Models.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        // Mapeando a tabela livros para o SQl
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMapping());
            modelBuilder.ApplyConfiguration(new LivroMapping());
        }
    }
}
