using System.Globalization;

/*
    ordem sugerida para implementação de membros:

    atributos privados
    propriedades autoimplementadas
    construtores
    propriedades customizadas
    outros métodos da classe
*/

namespace Course
{
   public class Produto
    {
        private string _nome = "";

        public double Preco { get; private set; }
        public int Quantidade { get; private set; }

        public Produto()
        {
            Quantidade = 10;
        }

        public Produto(string nome, double preco) : this()
        {
            _nome = nome;
            Preco = preco;
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                //value = passado na atribuição C# infere que é o parametro
                if (value != null && value.Length > 1)
                {
                    _nome = value;
                }
            }
        }

        public double ValorTotalEstoque()
        {
            return Preco * Quantidade;
        }

        public void AdicionarProdutos(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverProdutos(int quantidade)
        {
            Quantidade -= quantidade;
        }

        public override string ToString()
        {
            return _nome
                + " " + Preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + Quantidade
                + " unidades, Totoal: $ "
                + ValorTotalEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}