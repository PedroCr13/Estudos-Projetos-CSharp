using MockDemo.Interfaces;
using MockDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Usando MOQ serão criados testes para a classe ClienteService. 

    Mock: teste de uma classe especifica sem se precupar com as dependências
    será criada uma classe simulado a dependência que imitará seu comportamento
    imita o comportamento do objeto de forma controlada e pré definida (como um ator)
    será criado um projeto de testes e nele instalada a extensão MOQ.
*/

namespace MockDemo.Services
{
    public class ClienteService : IClienteService
    {
        // Depedência injetada usada em todos os metódos
        // para o teste será necessário usar mock
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
