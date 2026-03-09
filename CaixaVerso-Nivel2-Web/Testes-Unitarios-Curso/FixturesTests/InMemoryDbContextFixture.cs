using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Fixtures: variável comum a todos os testes (contextos compartilhados)
    útil em situações onde há a necessidade de criar uma única instância de uma variável
    que será acessada por todos os casos de testes de uma classe
      
    IClassFixture<T> (Xunit)
*/

namespace FixturesTests
{
    public class InMemoryDbContextFixture
    {
        public InMemoryDbContext Context { get; private set; }

        // instanciar a classe de contexto
        public InMemoryDbContextFixture()
        {
            Context = new InMemoryDbContext();

            // inicializar dados iniciais
        }

        public void Dispose()
        { 
            // limpeza do banco dados...
        }
    }
}
