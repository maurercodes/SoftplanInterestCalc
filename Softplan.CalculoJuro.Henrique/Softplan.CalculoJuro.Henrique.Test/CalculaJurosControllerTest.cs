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
        public void Test1()
        {
            Assert.Pass();
        }
    }
}