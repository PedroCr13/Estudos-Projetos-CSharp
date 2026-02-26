using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

/*
   Duas classes Cliente, porém, a cliente interna o campo é CPF é long
   e o cpf da "ApiExterna" é string.
   para fazer as classes serem compatíveis foi criado um ClienteAdapter
   contendo metodo "adaptando" um cliente recebido da API externa para um cliente interno
*/

namespace DesignPatternsEstruturais.Adapter
{
    public class ClienteApiExterna
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }

    public class Cliente
    { 
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Cpf { get; set; }
    }

    public static class ClienteAdapter
    {
        // metodo "adaptando" um cliente recebido da API externa para um cliente interno
        public static Cliente ConverterParaCliente(this ClienteApiExterna cliente)
        {
            return new Cliente
            {
                NomeCompleto = $"{cliente.Nome} {cliente.SobreNome}",
                DataNascimento = cliente.DataNascimento,
                Cpf = long.Parse(cliente.Cpf.Replace(".", string.Empty).Replace("-", string.Empty))
            };
        }
    }

    // console simula banco 
    public class BancoDeDados
    {
        public void SalvarCliente(Cliente cliente)
        {
            Console.WriteLine($"Cliente {cliente.NomeCompleto} salvo com sucesso!");
        }
    }
}
