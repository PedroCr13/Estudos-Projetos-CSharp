using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIniPortfolioDeInvestimentos.Models
{
    public interface IAtivoComVencimento
    {
        DateTime DataVencimento { get; }
        int DiasParaVencimento();
    }
}
