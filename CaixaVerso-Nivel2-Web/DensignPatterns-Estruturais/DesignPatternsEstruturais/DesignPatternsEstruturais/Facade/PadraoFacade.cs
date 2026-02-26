using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Facade: é um padrão de projeto estrutural que fornece uma interface simplificada
    para uma biblioteca, um framework, ou qualquer cojunto complexo de classes

    Uma única interface ("fachada") simplificada para um conjunto complexo de classes
    uma interface única, mas que por trás está ocorrendo processamento complexo.

    No exemplo, é chamado o metodo emprestar livro pelo programa principal, 
    no qual por trás dos panos é feito processamento do empréstimo, verificado status do usuario
    verificado a disponibilidade do livro, regista o empréstimo (4 passos)
    para o usuário foi realizado apenas um passo
 */

namespace DesignPatternsEstruturais.Facade
{
    public class SistemaDeInventario
    {
        private Dictionary<string, int> inventario = new Dictionary<string, int>
        {
            { "1984", 4},
            { "O Senhor Dos Anéis", 2}
        };

        public bool VerificaDisponibilidade(string livro)
        {
            if (inventario.ContainsKey(livro) && inventario[livro] > 0)
            {
                Console.WriteLine($"O livro {livro} está disponível.");
                return true;
            }
            else
            { 
                Console.WriteLine($"O livro {livro} não está diponível");
                return false;
            }
        }

        public void AtualizarInventario(string livro)
        {
            if (inventario.ContainsKey(livro) && inventario[livro] > 0)
            { 
                // remove o livro do estoque
                inventario[livro]--;
            }
        }
    }

    public class SistemaDeUsuarios
    {
        public bool VerificarStatusUsuario(string usuario)
        { 
            Console.WriteLine($"Status do usuário: {usuario} veificado.");
            return true;
        }
    }

    public class SistemaDeEmprestimos
    {
        public void RegistrarEmprestimo(string usuario, string livro)
        {
            Console.WriteLine($"Emprestimo de livro {livro} para o usuario: {usuario}");
        }
    }

    public class BibliotecaFacade
    {
        private SistemaDeInventario inventario = new SistemaDeInventario();
        private SistemaDeUsuarios usuarios = new SistemaDeUsuarios();
        private SistemaDeEmprestimos emprestimo = new SistemaDeEmprestimos();
        public void EmprestarLivro(string usuario, string livro)
        {
            Console.WriteLine("Processando o empréstimo...");
            if (usuarios.VerificarStatusUsuario(usuario) && inventario.VerificaDisponibilidade(livro))
            {
                emprestimo.RegistrarEmprestimo(usuario, livro);
                inventario.AtualizarInventario(livro);
            }
        }
    }
}
