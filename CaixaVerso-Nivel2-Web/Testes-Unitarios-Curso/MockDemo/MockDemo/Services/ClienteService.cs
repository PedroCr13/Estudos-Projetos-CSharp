using MockDemo.Interfaces;
using MockDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Usando MOQ serão criados testes para a classe ClienteService. 
 
*/

namespace MockDemo.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clientRepository                )
        {
            _clienteRepository = clientRepository;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Adicionar(cliente);
        }

        public void Dispose()
        { 
            throw new NotImplementedException();
        }

    }
}
