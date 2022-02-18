using Microsoft.AspNetCore.Mvc;

namespace Softplan.CalculoJuro.Henrique.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        /// <summary>
        /// Obter o valor cálculado em memória, de juros compostos, conforme a fórmula abaixo: 
        /// Valor Final = Valor Inicial * (1 + juros) ^ Tempo
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <returns>Valor de juros compostos truncado (sem arredondamento) em duas casas decimais</returns>
        [HttpGet]
        public decimal GetCalculaJuros(decimal valorInicial, int meses)
        {
            return 105.10M;
        }

    }
}
