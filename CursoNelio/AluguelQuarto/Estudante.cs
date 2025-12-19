using System;

namespace Locacao
{
    class Estudante
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Estudante(string nome, string email)
        {
            Nome = nome;
            email = email;
        }

        public override string ToString()
        {
            return Nome + ", " + Email;
        }
    }
}