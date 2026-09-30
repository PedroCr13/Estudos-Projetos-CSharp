using MIniPortfolioDeInvestimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIniPortfolioDeInvestimentos.ClassesAtivos
{
    public class TituloRendaFixa : IAtivoFinanceiro, IAtivoComVencimento
    {
        public string Nome { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal TaxaAnual { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime DataVencimento { get; set; }

        public decimal ValorAtual
        {
            get 
            {
                var dias = (DateTime.Now - DataAplicacao).Days;
                var rentabilidade = TaxaAnual * (dias / 365m);
                return ValorInvestido * (1 + rentabilidade / 100m);
            }
        }

        public decimal CalcularRentabilidade()
        {
            var dias = (DateTime.Now - DataAplicacao).Days;
            return TaxaAnual * (dias / 365m);
        }

        public int DiasParaVencimento() => (DataVencimento - DateTime.Now).Days;
    }
}
