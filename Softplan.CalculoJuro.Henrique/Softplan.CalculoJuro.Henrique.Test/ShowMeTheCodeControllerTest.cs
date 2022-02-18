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
        public void Deve_Retornar_Url_Do_Fonte_GitHub()
        {
            var url = _showMeTheCodeController.GetShowMeTheCode();
            Assert.IsTrue(url.ContentType == "text/html");
            var minhaUrlGitHub = @"https://github.com/maurercodes/SoftplanInterestCalc";
            Assert.IsTrue(url.Content.Contains(minhaUrlGitHub));
        }
    }
}