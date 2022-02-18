using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Softplan.CalculoJuro.Henrique.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Deverá retornar a url de onde encontra-se o fonte no github
        /// </summary>
        /// <returns>Url para o fonte no Github</returns>
        [HttpGet]
        public ContentResult GetShowMeTheCode()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><body><p><a href= https://github.com/maurercodes/SoftplanInterestCalc> SoftplanInterestCalc On GitHub</a></p></body></html>"
            };
        }
    }
}
