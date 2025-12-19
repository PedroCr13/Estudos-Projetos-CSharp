using System.Globalization;

namespace Course
{
    public class Produto
    {
        private string _nome = "";
        private double _preco;
        private int _quantidade;

        public Produto() {
            _quantidade = 10;
        }

        public Produto(string nome, double preco) : this()
        {
            _nome = nome;
            _preco = preco;
        }

        public string getNome()
        {
            return _nome;
        }

        public void setNome(string nome)
        {
            if (nome != null && nome.Length > 1)
            {
                _nome = nome;
            }
        }

        public double getPreco()
        {
            return _preco;
        }

        public int getQuantidade()
        {
            return _quantidade;
        }

        public double ValorTotalEstoque()
        {
            return _preco * _quantidade;
        }

        public void AdicionarProdutos(int quantidade)
        {
            _quantidade += quantidade;
        }

        public void RemoverProdutos(int quantidade)
        {
            _quantidade -= quantidade;
        }

        public override string ToString()
        {
            return _nome
                + " " + _preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + _quantidade
                + " unidades, Totoal: $ "
                + ValorTotalEstoque().ToString("F2", CultureInfo.InvariantCulture);   
        }
    }
}