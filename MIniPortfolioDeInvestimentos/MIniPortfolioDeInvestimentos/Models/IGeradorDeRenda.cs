using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIniPortfolioDeInvestimentos.Models
{
    public interface IGeradorDeRenda
    {
        string Periodicidade { get; }
        decimal CalcularRendaPeriodica();
    }
}
