using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            var produtos = new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    Nome = "Celular",
                    Descricao = "Nokia 1600",
                    Preco = 80.00,
                    Quantidade = 10,
                },
                new Produto
                {
                    Id = 2,
                    Nome = "TV",
                    Descricao = "Panasonic",
                    Preco = 150.00,
                    Quantidade = 8,
                }
            };
            return View(produtos);
        }
    }
}