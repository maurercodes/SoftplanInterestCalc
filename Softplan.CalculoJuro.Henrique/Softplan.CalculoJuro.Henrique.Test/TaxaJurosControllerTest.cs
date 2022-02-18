using NUnit.Framework;
using Softplan.CalculoJuro.Henrique.Controllers;
using System.Net.Http;

namespace Softplan.CalculoJuro.Henrique.Test
{
    public class TaxaJurosControllerTest
    {
        private TaxaJurosController _taxaJurosController;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _taxaJurosController = new TaxaJurosController();
            _httpClient = new HttpClient();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}