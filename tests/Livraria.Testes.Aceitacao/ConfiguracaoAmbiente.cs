using Livraria.Api.Infraestrutura;
using Livraria.Aplicacao;
using Livraria.Testes.Comum;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using System.IO;
using System.Threading;

namespace Livraria.Testes.Aceitacao
{
    [SetUpFixture]
    class ConfiguracaoAmbiente
    {
        private IWebHost _webHost;
        private string _testLocalHostUrl;

        [OneTimeSetUp]
        public void Inicializar()
        {
            var projectName = typeof(Startup).Assembly.GetName().Name;
            var caminhoProjeto = Path.Combine(Localizador.ObterCaminhoDaSolution(), "src", projectName);
            var tokenSource = new CancellationTokenSource();

            Contexto.Configuration = GerenciadorConfiguracoes.BuildConfiguration();

            GerenciadorLiteDb.CriarBackupBaseCasoNaoExista(
                    Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);

            _testLocalHostUrl = Contexto.UrlBaseLivraria;

            _webHost = WebHost.CreateDefaultBuilder(new string[0])
                .UseSetting(WebHostDefaults.ApplicationKey, projectName)
                .UseContentRoot(caminhoProjeto)
                .UseEnvironment(EnvironmentName.Development)
                .UseUrls(_testLocalHostUrl)
                .UseStartup<Startup>()
                .Build();

            _webHost.RunAsync(tokenSource.Token);

            GerenciadorWebDriver.Inicializar();
        }

        [OneTimeTearDown]
        public void Finalizar()
        {
            GerenciadorWebDriver.Driver?.Quit();
            _webHost?.Dispose();
        }
    }
}
