using Livraria.Testes.Comum;
using NUnit.Framework;

namespace Livraria.Testes.Aceitacao
{
    class TesteAceitacao
    {
        [TearDown]
        public void RodarAposCadaTeste()
        {
            GerenciadorLiteDb
                .RestaurarBackupComoBasePrincipal(
                    Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);
        }
    }
}
