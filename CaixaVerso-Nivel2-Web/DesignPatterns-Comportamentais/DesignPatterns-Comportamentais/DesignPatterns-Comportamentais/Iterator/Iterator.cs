using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Padrão Iterator:
    Padrão de projeto comportamental que permite percorrer elementos
    de uma coleção sem expor a representação dele (lista, pilha, árvore, grafo, etc)
    Fornece uma única interface que permite percorrer de diversas maneiras
    
*/

namespace DesignPatterns_Comportamentais.Iterator
{
    public interface IIterator<T>
    {
        bool HasNext();

        T Next();
    }

    public interface IAgregate<T>
    {
        IIterator<T> CreateIterator();
    }

    public class Biblioteca : IAgregate<Livro>
    {
        private List<Livro> _livros = new List<Livro>();

        public void Add(Livro livro)
        { 
            _livros.Add(livro); 
        }

        public IIterator<Livro> CreateIterator()
        {
            return new BibliotecaIterator(this);
        }

        public int Count
        {
            get { return _livros.Count; }
        }

        public Livro Get(int index)
        { 
            return _livros[index];
        }
    }

    public class BibliotecaIterator : IIterator<Livro>
    {
        private Biblioteca _biblioteca;
        private int _current = 0;

        public BibliotecaIterator(Biblioteca biblioteca)
        {
            _biblioteca = biblioteca;   
        }

        public bool HasNext()
        { 
            return _current < _biblioteca.Count;
        }

        public Livro Next()
        {
            return _biblioteca.Get(_current++);
        }
    }

    public class Livro
    { 
        public string Titulo { get; private set; }
        public string Autor { get; private set; }

        public Livro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }
    }
}
