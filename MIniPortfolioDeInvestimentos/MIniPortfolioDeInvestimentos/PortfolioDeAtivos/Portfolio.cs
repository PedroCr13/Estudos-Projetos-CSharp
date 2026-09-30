using MIniPortfolioDeInvestimentos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIniPortfolioDeInvestimentos.PortfolioDeAtivos
{
    public class Portfolio<T> where T : IAtivoFinanceiro
    {
        private List<T> _ativos = new();

        public void AdicionarAtivo(T ativo) => _ativos.Add(ativo);

        public decimal ValorTotal => _ativos.Sum(a => a.ValorAtual);

        public decimal CalcularRentabilidadeMediaPonderada()
        {
            var valorTotal = ValorTotal;

            if (valorTotal == 0) return 0;

            return _ativos.Sum(a => a.CalcularRentabilidade() * a.ValorAtual) / valorTotal; 
        }

        public decimal CalcularRendaPeriodicaTotal()
        {
            var ativosComRendaPeriodica = FiltrarPor(a => a is IGeradorDeRenda);

            return ativosComRendaPeriodica
                .Cast<IGeradorDeRenda>()
                .Sum(a => a.CalcularRendaPeriodica());
        }

        public IEnumerable<IAtivoComVencimento> AtivosProximoDoVencimento(int dias)
        {
            var ativosComVencimento = FiltrarPor(a => a is IAtivoComVencimento); 

            return ativosComVencimento
                .Cast<IAtivoComVencimento>()
                .Where(a => a.DiasParaVencimento() <= dias);
        }

        public IEnumerable<T> FiltrarPor(Func<T, bool> predicado) => _ativos.Where(predicado);

    }
}
