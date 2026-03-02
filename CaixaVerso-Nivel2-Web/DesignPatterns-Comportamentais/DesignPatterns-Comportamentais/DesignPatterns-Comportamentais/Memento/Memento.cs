using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*
    Memmento: (lembrança, historico, snapchot)
    Padrão de projeto comportamental que permite salvar e restaurar o estado 
    anterior de um objeto sem revelar detalhes de sua implementação.
*/

namespace DesignPatterns_Comportamentais.Memento
{
    public class TextoMemento
    { 
        public string Estado { get; }

        public TextoMemento(string estado       )
        {
            Estado = estado;
        }
    }

    public class EditorTexto
    {
        public string Conteudo { get; set; }

        public TextoMemento SalvarEstado()
        {
            return new TextoMemento(Conteudo);
        }

        public void RestaurarEstado(TextoMemento memento)
        {
            Conteudo = memento.Estado;
        }
    }

    public class Caretaker
    {
        private List<TextoMemento> mementos = new List<TextoMemento>();
        private EditorTexto editor;

        public Caretaker(EditorTexto editor)
        { 
            this.editor = editor;   
        }

        public void Salvar()
        {
            mementos.Add(editor.SalvarEstado());
        }

        public void Desfazer(int indice)
        {
            if (indice < 0 || indice > mementos.Count)
                throw new IndexOutOfRangeException("Indice fora do alcance.");

            editor.RestaurarEstado(mementos[indice]);
        }
    }
}
