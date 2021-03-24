using Livraria.Testes.Comum;
using NUnit.Framework;

namespace Livraria.Testes.Integracao.BD
{
    [SetUpFixture]
    class ConfiguracaoAmbiente
    {
        [OneTimeSetUp]
        public void Inicializar()
        {
            Contexto.Configuration = GerenciadorConfiguracoes.BuildConfiguration();

            GerenciadorLiteDb
                .CriarBackupBaseCasoNaoExista(Contexto.DataBaseDirectory, Contexto.BackupDbName, Contexto.DbName);
        }

        [OneTimeTearDown]
        public void Finalizar()
        {
            GerenciadorLiteDb
                .RestaurarBackupComoBasePrincipal(Contexto.DataBaseDirectory, Contexto.BackupDbName, Contexto.DbName);
        }
    }
}
