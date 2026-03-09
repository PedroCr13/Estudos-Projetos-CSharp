using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixturesTests
{
    public class InMemoryDbContext : IClassFixture<InMemoryDbContext>
    {
        // objeto não será criado a cada execução de um teste, será compartilhado com todos
        InMemoryDbContextFixture _fixture;

        public InMemoryDbContext(InMemoryDbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public void WithNoItens_CoutShouldReturnZero()
        {
            var count = _fixture.Context.Users.Count();
            Assert.Equal(0, count);
        }

        [Fact]
        public void AfterAddingItem_CountShouldReturnOne()
        {
            _fixture.Context.Users.Add(new User());
            var count = _fixture.Context.Users.Count();
            Assert.Equal(1, count);
        }
    }
}
