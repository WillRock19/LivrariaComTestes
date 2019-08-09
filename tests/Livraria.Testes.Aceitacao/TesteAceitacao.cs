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
                .RecriarColecaoAPartirDoBackup(
                    Contexto.DataBaseDirectory, Contexto.BackupDbName, Contexto.DbName);
        }
    }
}
