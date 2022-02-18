using Microsoft.AspNetCore.Mvc;

namespace Softplan.CalculoJuro.Henrique.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna taxa de juros
        /// </summary>
        /// <returns>Retorna o juros de 1% ou 0,01</returns>
        [HttpGet]
        public float GetTaxaJuros()
        {
            return 0.01f;
        }

    }
}
