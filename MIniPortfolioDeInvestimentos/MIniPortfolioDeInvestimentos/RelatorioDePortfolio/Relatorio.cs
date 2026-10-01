using MIniPortfolioDeInvestimentos.Models;
using MIniPortfolioDeInvestimentos.PortfolioDeAtivos;

namespace MIniPortfolioDeInvestimentos.RelatorioDeAtivos
{
    public static class Relatorio
    {
        public static void Gerar<T>(Portfolio<T> portfolio) where T : IAtivoFinanceiro
        {
            MostrarResumoPortfolio(portfolio);
            MostrarAtivosProximosDoVencimento(portfolio, 180);
            MostrarRendaPeriodicaTotal(portfolio);
            MostrarDetalhesAtivos(portfolio);
        }

        private static void MostrarResumoPortfolio<T>(Portfolio<T> portfolio) where T : IAtivoFinanceiro
        {
            Console.WriteLine("=== Portfólio de Investimentos ===");
            Console.WriteLine($"Valor Total: {portfolio.ValorTotal:C}");
            Console.WriteLine($"Rentabilidade Média Ponderada: {portfolio.CalcularRentabilidadeMediaPonderada():F2}%");
            Console.WriteLine();
        }

        private static void MostrarAtivosProximosDoVencimento<T>(Portfolio<T> portfolio, int dias) where T : IAtivoFinanceiro
        {

            Console.WriteLine($"=== Ativos próximos do vencimento ===");
            Console.WriteLine("(próximos 180 dias )");

            foreach (var ativo in portfolio.AtivosProximoDoVencimento(180))
            {
                Console.WriteLine($"- {((IAtivoFinanceiro)ativo).Nome} vence em {ativo.DiasParaVencimento()} dias");
            }
            Console.WriteLine();
        }

        private static void MostrarRendaPeriodicaTotal<T>(Portfolio<T> portfolio) where T : IAtivoFinanceiro
        {
            Console.WriteLine("=== Renda Periódica Total ===");
            Console.WriteLine($"{portfolio.CalcularRendaPeriodicaTotal():C}");
            Console.WriteLine();
        }

        private static void MostrarDetalhesAtivos<T>(Portfolio<T> portfolio) where T : IAtivoFinanceiro
        {
            Console.WriteLine("Relatório Dinâmico (via Reflection)");
            foreach (var ativo in portfolio.FiltrarPor(a => true))
            {
                var tipo = ativo.GetType();
                Console.WriteLine($"Tipo: {tipo.Name}");

                foreach (var prop in tipo.GetProperties())
                {
                    var valor = prop.GetValue(ativo);

                    Console.WriteLine($"{prop.Name}: {FormatarValor(valor, prop.Name)}");
                }

                Console.WriteLine($"Rentabilidade: {ativo.CalcularRentabilidade():F2}%");

                var interfaces = tipo.GetInterfaces();
                Console.WriteLine("-> Implementa: " + string.Join(", ", interfaces.Select(i => i.Name)));
                Console.WriteLine();
            }
        }

        private static string FormatarValor(object valor, string propName = "")
        {
            if (valor == null) return string.Empty;

            if (valor is decimal dec)
            {
                // Se o nome da propriedade indicar percentual
                if (propName.Contains("Taxa") || propName.Contains("Variacao") || propName.Contains("Rentabilidade"))
                    return $"{dec:F2}%";

                // Caso contrário, trata como moeda
                return dec.ToString("C");
            }

            if (valor is int i) return i.ToString();
            if (valor is double d) return d.ToString("F2");
            if (valor is DateTime dt) return dt.ToString("dd/MM/yyyy");

            return valor.ToString();
        }
    }
}
