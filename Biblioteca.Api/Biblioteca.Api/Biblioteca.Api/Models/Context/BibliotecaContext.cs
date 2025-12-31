using Biblioteca.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Models.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options) { }

        public DbSet<Livro> Livros { get; set; }

        // Mapeando a tabela livros para o SQl
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("livros");
        }
    }
}
