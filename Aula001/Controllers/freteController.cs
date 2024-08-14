using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreteController : ControllerBase
    {
        [HttpPost]
        public IActionResult CalcularFrete([FromBody] ProdutoInputModel produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            var tarifasPorEstado = new Dictionary<string, decimal>
            {
                { "SP", 50.00m },
                { "RJ", 60.00m },
                { "MG", 55.00m },
                { "OUTROS", 70.00m }
            };

            decimal volume = (decimal)(produto.Altura * produto.Largura * produto.Comprimento);

            var taxaPorCm3 = 0.01m;

            if (!tarifasPorEstado.TryGetValue(produto.UF.ToUpper(), out decimal tarifaPorEstado))
            {
                tarifaPorEstado = tarifasPorEstado["OUTROS"];
            }

            var valorFrete = (volume * taxaPorCm3) + tarifaPorEstado;

            return Ok(new { ValorFrete = valorFrete });
        }
    }


    public class ProdutoInputModel
    {
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Comprimento { get; set; }
        public string UF { get; set; }
    }
}
