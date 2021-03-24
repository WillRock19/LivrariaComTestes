using Livraria.Testes.Comum;
using NUnit.Framework;

namespace Livraria.Testes.Integracao.BD
{
    class TesteIntegracao
    {
        [TearDown]
        public void ExecutarAposCadaTeste()
        {
            GerenciadorLiteDb
                .RecriarColecaoAPartirDoBackup(
                    Contexto.DataBaseDirectory, Contexto.BackupDbName, Contexto.DbName);
        }
    }
}
