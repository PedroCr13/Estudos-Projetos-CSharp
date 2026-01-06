namespace Biblioteca.Api.Common
{
    public class ErroResponse
    {
        public List<ErroItem> Erros { get; set; } = new();
    }

    public class ErroItem
    { 
        public string Campo { get; set; }
        public string Mensagem { get; set; }
    }
}
