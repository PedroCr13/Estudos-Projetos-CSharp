using MIniPortfolioDeInvestimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIniPortfolioDeInvestimentos.ClassesAtivos
{
    internal class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegociavel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoMedioCompra { get; set; }
        public decimal PrecoMercado { get; set; }
        public decimal DividendosRecebidos { get; set; }
        public decimal DividendosPorAcao { get; set; }
        public string Periodicidade { get; set; }
        public decimal VariacaoDiaria { get; set; }

        public decimal ValorInvestido => Quantidade * PrecoMedioCompra;
        public decimal ValorAtual => Quantidade * PrecoMercado;

        public decimal CalcularRendaPeriodica() => Quantidade * DividendosPorAcao;

        public decimal CalcularRentabilidade()
        { 
            return ((ValorAtual + DividendosRecebidos - ValorInvestido) / ValorInvestido) * 100m;
        }
    }
}
