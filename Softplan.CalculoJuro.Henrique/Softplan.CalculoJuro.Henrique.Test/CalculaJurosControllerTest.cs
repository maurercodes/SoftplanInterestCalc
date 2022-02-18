using NUnit.Framework;
using Softplan.CalculoJuro.Henrique.Controllers;
using System.Net.Http;

namespace Softplan.CalculoJuro.Henrique.Test
{
    public class CalculaJurosControllerTest
    {

        private CalculaJurosController _calculaJurosController;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _calculaJurosController = new CalculaJurosController();
            _httpClient = new HttpClient();
        }

        [Test]
        public void Deve_Retornar_Valor_Truncado_Sem_Arredondamento_Com_Duas_Casas_Decimais()
        {
            // Valor Esperado para /calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10
            var jurosComposto = _calculaJurosController.GetCalculaJuros(100, 5);
            Assert.IsTrue(jurosComposto == 105.10M);
        }
    }
}