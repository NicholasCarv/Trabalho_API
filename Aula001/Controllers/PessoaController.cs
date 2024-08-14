using Microsoft.AspNetCore.Mvc;

namespace Aula001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
 
        [HttpPost]
        [Route("calcular-imc")]
        public IActionResult CalcularIMC([FromBody] Pessoa pessoa)
        {
            double imc = pessoa.Peso / (pessoa.Altura * pessoa.Altura);
            return Ok(new { IMC = imc });
        }

        [HttpGet]
        [Route("consulta-tabela-imc")]
        public IActionResult ConsultaTabelaIMC(double imc)
        {
            string classificacao = GetIMCClassificacao(imc);
            return Ok(new { IMC = imc, Classificacao = classificacao });
        }

        private string GetIMCClassificacao(double imc)
        {
            if (imc < 18.5)
                return "Abaixo do peso";
            else if (imc >= 18.5 && imc < 24.9)
                return "Peso normal";
            else if (imc >= 25 && imc < 29.9)
                return "Sobrepeso";
            else if (imc >= 30 && imc < 34.9)
                return "Obesidade Grau 1";
            else if (imc >= 35 && imc < 39.9)
                return "Obesidade Grau 2";
            else
                return "Obesidade Grau 3";
        }
    }

    public class Pessoa
    {
        public string Nome { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}

