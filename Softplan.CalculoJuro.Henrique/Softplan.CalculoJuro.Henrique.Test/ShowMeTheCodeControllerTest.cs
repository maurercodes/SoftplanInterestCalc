using NUnit.Framework;
using Softplan.CalculoJuro.Henrique.Controllers;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Softplan.CalculoJuro.Henrique.Test
{
    public class ShowMeTheCodeControllerTest 
    {

        private ShowMeTheCodeController _showMeTheCodeController;
        private HttpClient _httpClient;
        private Process _process;

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

        [Test]
        public async Task Deve_Responder_PathRelativo_ShowMeTheCode()
        {

            // pré-condição de testes de integração
            var projectName = _showMeTheCodeController.GetType().Assembly.GetName().Name;
            string pathProject = string.Concat(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent, @"\", projectName);
            _process = Process.Start(@"C:\WINDOWS\System32\WindowsPowerShell\v1.0\powershell.exe", $"dotnet run --project {pathProject}");

            var response = await _httpClient.GetAsync("https://localhost:5001/ShowMeTheCode");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            var htmlBody = await response.Content.ReadAsStringAsync();

            var minhaUrlGitHub = @"https://github.com/maurercodes/SoftplanInterestCalc";
            Assert.IsTrue(htmlBody.Contains(minhaUrlGitHub));

            if (_process != null) _process.Kill(true);
            _httpClient.Dispose();
        }
    }
}