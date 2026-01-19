using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Anotações aula Singleton:
    
  usado para garantir uma única instância de um classe em toda a aplicação
  proporciona um ponto de acesso global para esta instância
  util em recursos compartilhados, exemplo: conexão a banco de dados

  Definição Refactoring Guru:
  "O Singleton é um padrão de projeto criacional 
  que permite a você garantir que uma classe tenha apenas uma instância, 
  enquanto provê um ponto de acesso global para essa instância"

  Site com muitas informações sobre os padrões
  https://refactoring.guru/pt-br/design-patterns/

  Este exemplo demonstra o padrão Singleton, cujo objetivo é garantir
  que apenas UMA instância da classe exista durante toda a execução
  da aplicação.

  A classe MeuBancoDeDados possui:
  - Um construtor implícito privado (impedindo new externo)
  - Um atributo estático que guarda a única instância
  - Um método estático que controla a criação e o acesso à instância

  No Program.cs, ao solicitar a instância duas vezes, ambas as variáveis
  apontam para o mesmo objeto, comprovando o funcionamento do padrão
*/

namespace DensignPatterns.Criacionais.Singleton
{
    internal class MeuBancoDeDados
    {
        // Método estático que permanece com o mesmo valor na aplicação toda
        private static MeuBancoDeDados _instancia;

        public static MeuBancoDeDados ObterInstancia()
        {
            if (_instancia == null)
            { 
                _instancia = new MeuBancoDeDados();
            }

            return _instancia;
        }
    }
}
