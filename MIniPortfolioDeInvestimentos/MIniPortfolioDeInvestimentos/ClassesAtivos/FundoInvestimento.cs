using MIniPortfolioDeInvestimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIniPortfolioDeInvestimentos.ClassesAtivos
{
    public class FundoInvestimento : IAtivoFinanceiro, IGeradorDeRenda
    {
        public string Nome { get; set; }
        public int QuantidadeCotas { get; set; }
        public decimal ValorCotaCompra { get; set; }
        public decimal ValorCotaAtual { get; set; }
        public decimal TaxaAdministracao { get; set; }
        public decimal RendimentoPorCota { get; set; }
        public string Periodicidade { get; set; }

        public decimal ValorInvestido => QuantidadeCotas * ValorCotaCompra;
        public decimal ValorAtual => QuantidadeCotas * ValorCotaAtual;

        public decimal CalcularRentabilidade()
        {
            return ((ValorCotaAtual - ValorCotaCompra) / ValorCotaCompra) * 100m;
        }
        public decimal CalcularRendaPeriodica() => QuantidadeCotas * RendimentoPorCota;
    }
}
