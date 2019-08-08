using Livraria.Testes.Comum;
using NUnit.Framework;

namespace Livraria.Testes.Integracao
{
    class TesteIntegracao
    {
        [TearDown]
        public void ExecutarAposCadaTeste()
        {
            GerenciadorLiteDb
                .RecriarColecao(
                    Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);
        }
    }
}
