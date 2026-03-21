/*
    Clean Architecture: 
    
    É um padrão de design de software proposto por Robert C. Martin (Uncle Bob) que organiza o código 
    em camadas concêntricas para separar regras de negócio de detalhes técnicos (como bancos de dados ou frameworks). 
    O objetivo principal é criar sistemas testáveis, fáceis de manter e independentes de tecnologia

    Principais Conceitos e Estrutura:
    Independência de Frameworks: O framework é tratado como uma ferramenta, não como a base da aplicação.
    Regra de Dependência: As dependências de código devem apontar apenas para dentro, em direção às regras de negócio (núcleo).
 
    Vantagens:

    Testabilidade: As regras de negócio podem ser testadas sem UI, banco de dados ou servidor web.
    Facilidade de Manutenção: A separação de responsabilidades torna o código mais fácil de entender e alterar.
    Independência de Banco de Dados: É possível trocar o banco de dados (ex: SQL para NoSQL) sem afetar a lógica de negócios

    a Clean Architecture foca em proteger as regras de negócio mais importantes, tornando-as o centro da aplicação 
    e não reféns de tecnologias externas.

    Exemplo de organização do projeto .Net:

    Domain (ou core): entidades, enums, regras
    Application: Lógica de negócio, casos de uso
    Infrastructure: conexão com serviços externos
    Presentation: interface com o usuário.
 */

namespace Aula.Api.Services
{
    public class CalculadoraService
    {
        public int Somar(int a, int b)
        { 
            return a + b;
        }

        public int Subtrair(int a, int b)
        {
            return a - b;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public int Dividir(int a, int b)
        {
            return a / b;
        }
    }
}
