using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Somente os dados que o aluno irá precisar preencher no front 
*/

namespace Aula.Application.Requests
{
    public class CriarAlunoRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
    }
}
