using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    DDD Entidades anêmicas: entidades que não possuem comportamento 
    entidades com metodos privados, construidas por construtor com parâmetros
    quanto mais simples para instanciar uma entidade, menos construtores tiver
    menos complexidade melhor

    aluno vai preencher nome, email e cep apenas
    demais dados do endereço preenchidos de acordo com o cep (automatico)
    data preenchida pelo sistema
*/

namespace Aula.Core.Entities
{
    public class Aluno
    {
        public int Id { get; set; } 
        public string Nome { get; set; }    
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Endereco {  get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime CriadoEm { get; set; }

        // exemplo de regra negócio: aluno deve morar em MG
        public bool AlunoMoraEmMinasGerais()
        {
            return Uf == "MG";
        }
    }
}
