using Microsoft.AspNetCore.Mvc;
using System;

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
            var taxaJurosController = new TaxaJurosController();
            double taxaJurosFixada = taxaJurosController.GetTaxaJuros();
            decimal juroComposto = valorInicial * Convert.ToDecimal(Math.Pow(1 + taxaJurosFixada, meses));
            //Truncar sem arredondar em duas casas decimais
            return Convert.ToDecimal($"{Math.Truncate(100 * juroComposto) / 100:F2}");
        }

    }
}
