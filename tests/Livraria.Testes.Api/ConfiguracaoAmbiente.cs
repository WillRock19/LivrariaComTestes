using Livraria.Api;
using Livraria.Api.Infraestrutura;
using Livraria.Testes.Comum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.IO;

namespace Livraria.Testes.Api
{
    [SetUpFixture]
    class ConfiguracaoAmbiente
    {
        [OneTimeSetUp]
        public void Inicializar()
        {
            Contexto.Configuration = GerenciadorConfiguracoes.BuildConfiguration();

            GerenciadorLiteDb
                .CriarBackupBaseCasoNaoExista(Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);

            var caminhoBase = Localizador.ObterCaminhoDaSolution();
            var caminhoProjeto = Path.Combine(caminhoBase, "src", "Cadastro.ProspeccaoCliente");

            var builder = Program.CreateWebHostBuilder(new string[] { })
                .UseContentRoot(caminhoProjeto)
                .UseEnvironment("Testing");

            var server = new TestServer(builder);
            Contexto.Client = server.CreateClient();
        }

        [OneTimeTearDown]
        public void Finalizar()
        {
            Contexto.Client?.Dispose();
            GerenciadorLiteDb
                .RestaurarBackupComoBasePrincipal(Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);
        }
    }
}
