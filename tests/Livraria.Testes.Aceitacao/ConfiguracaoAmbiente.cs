using Livraria.Api.Infraestrutura;
using Livraria.Aplicacao;
using Livraria.Testes.Comum;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using System.IO;

namespace Livraria.Testes.Aceitacao
{
    [SetUpFixture]
    class ConfiguracaoAmbiente
    {
        private IWebHost _webHost;

        [OneTimeSetUp]
        public void Inicializar()
        {
            var projectName = typeof(Startup).Assembly.GetName().Name;
            var caminhoProjeto = Path.Combine(Localizador.ObterCaminhoDaSolution(), "src", projectName);

            Contexto.Configuration = GerenciadorConfiguracoes.BuildConfiguration();

            GerenciadorLiteDb.CriarBackupBaseCasoNaoExista(
                    Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);

            _webHost = WebHost.CreateDefaultBuilder(new string[0])
                .UseSetting(WebHostDefaults.ApplicationKey, projectName)
                .UseContentRoot(caminhoProjeto)
                .UseEnvironment(EnvironmentName.Development)
                .UseUrls(Contexto.UrlBaseLivraria)
                .UseStartup<Startup>()
                .Build();

            _webHost.RunAsync();

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
