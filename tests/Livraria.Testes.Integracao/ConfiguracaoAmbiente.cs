using Livraria.Testes.Comum;
using NUnit.Framework;

namespace Livraria.Testes.Integracao
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
        }

        [OneTimeTearDown]
        public void Finalizar()
        {
            GerenciadorLiteDb
                .RestaurarBackupComoBasePrincipal(Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);
        }
    }
}
