using NUnit.Framework;
using Softplan.CalculoJuro.Henrique.Controllers;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Softplan.CalculoJuro.Henrique.Test
{
    public class TaxaJurosControllerTest
    {
        private TaxaJurosController _taxaJurosController;
        private HttpClient _httpClient;
        private Process _process;

        [SetUp]
        public void Setup()
        {
            _taxaJurosController = new TaxaJurosController();
            _httpClient = new HttpClient();
        }

        [Test]
        public void Deve_Retornar_Taxa_de_Juros_Fixada_De_1Porcento()
        {
            var taxaJurosFixada = _taxaJurosController.GetTaxaJuros();

            Assert.IsTrue(taxaJurosFixada == 0.01f);
        }

        [Test]
        public async Task Deve_Responder_PathRelativo_taxaJuros()
        {
            // pré-condição de testes de integração
            var projectName = _taxaJurosController.GetType().Assembly.GetName().Name;
            string pathProject = string.Concat(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent, @"\", projectName);
            _process = Process.Start(@"C:\WINDOWS\System32\WindowsPowerShell\v1.0\powershell.exe", $"dotnet run --project {pathProject}");

            var response = await _httpClient.GetAsync("https://localhost:5001/taxaJuros");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            var strTaxaJuros = await response.Content.ReadAsStringAsync();

            float.TryParse(strTaxaJuros, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float taxaJurosFixada);

            Assert.IsTrue(taxaJurosFixada == 0.01f);

            if (_process != null) _process.Kill(true);
            _httpClient.Dispose();
        }
    }
}