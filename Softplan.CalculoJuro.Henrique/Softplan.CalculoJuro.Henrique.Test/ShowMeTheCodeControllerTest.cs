using NUnit.Framework;
using Softplan.CalculoJuro.Henrique.Controllers;
using System.Net.Http;

namespace Softplan.CalculoJuro.Henrique.Test
{
    public class ShowMeTheCodeControllerTest
    {

        private ShowMeTheCodeController _showMeTheCodeController;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _showMeTheCodeController = new ShowMeTheCodeController();
            _httpClient = new HttpClient();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}