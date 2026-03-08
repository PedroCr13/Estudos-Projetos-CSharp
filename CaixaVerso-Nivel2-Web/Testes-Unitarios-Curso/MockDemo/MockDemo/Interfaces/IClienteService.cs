using MockDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDemo.Interfaces
{
    public interface IClienteService : IDisposable
    {
        void Adicionar(Cliente cliente);
        IEnumerable<Cliente> ObterTodos();
    }
}
