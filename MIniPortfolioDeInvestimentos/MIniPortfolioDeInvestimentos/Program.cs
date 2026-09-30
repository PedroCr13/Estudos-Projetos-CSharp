using MIniPortfolioDeInvestimentos.ClassesAtivos;
using MIniPortfolioDeInvestimentos.Models;
using MIniPortfolioDeInvestimentos.PortfolioDeAtivos;
using MIniPortfolioDeInvestimentos.RelatorioDeAtivos;

namespace MIniPortfolioDeInvestimentos.Principal
{
    public class Program
    {
        static void Main(string[] args)
        {
            var portfolio = new Portfolio<IAtivoFinanceiro>();

            var acao = new Acao()
            {
                Nome = "CXSE3",
                Quantidade = 100,
                PrecoMedioCompra = 20.50m,
                PrecoMercado = 21.10m,
                DividendosRecebidos = 150m,
                DividendosPorAcao = 1.50m,
                Periodicidade = "Trimestral",
                VariacaoDiaria = 1.25m
            };

            var tituloRF = new TituloRendaFixa
            {
                Nome = "CDB Prefixado ",
                ValorInvestido = 4000m,
                TaxaAnual = 10m,
                DataAplicacao = new DateTime(2026, 1, 1),
                DataVencimento = new DateTime(2026, 11, 25)
            };

            var fundo = new FundoInvestimento
            {
                Nome = "Fundo RF Simples",
                QuantidadeCotas = 100,
                ValorCotaCompra = 15,
                ValorCotaAtual = 18,
                TaxaAdministracao = 1m,
                RendimentoPorCota = 0.10m,
                Periodicidade = "Mensal"
            };

            portfolio.AdicionarAtivo(acao);
            portfolio.AdicionarAtivo(tituloRF);
            portfolio.AdicionarAtivo(fundo);

            Relatorio.Gerar(portfolio);
        }
    }
}