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
    public class CalculaJurosControllerTest
    {

        private CalculaJurosController _calculaJurosController;
        private HttpClient _httpClient;
        private Process _process;

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

        [Test]
        public async Task Deve_Responder_PathRelativo_calculajuros()
        {
            // pré-condição de testes de integração
            var projectName = _calculaJurosController.GetType().Assembly.GetName().Name;
            string pathProject = string.Concat(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent, @"\", projectName);
            _process = Process.Start(@"C:\WINDOWS\System32\WindowsPowerShell\v1.0\powershell.exe", $"dotnet run --project {pathProject}");

            var response = await _httpClient.GetAsync(@"https://localhost:5001/calculajuros?valorInicial=100&meses=5");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            var strJuros = await response.Content.ReadAsStringAsync();

            decimal.TryParse(strJuros, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat, out decimal jurosComposto);

            Assert.IsTrue(jurosComposto == 105.10M);

            if (_process != null) _process.Kill(true);
            _httpClient.Dispose();
        }

    }
}