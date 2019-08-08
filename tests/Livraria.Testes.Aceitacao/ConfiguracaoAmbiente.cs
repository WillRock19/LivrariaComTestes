using Livraria.Testes.Comum;
using NUnit.Framework;

namespace Livraria.Testes.Aceitacao
{
    [SetUpFixture]
    class ConfiguracaoAmbiente
    {
        [OneTimeSetUp]
        public void Inicializar()
        {
            GerenciadorLiteDb.CriarBackupBaseCasoNaoExista(
                    Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);

            GerenciadorWebDriver.Inicializar();
        }

        [OneTimeTearDown]
        public void Finalizar() => 
            GerenciadorWebDriver.Driver.Dispose();
    }
}
