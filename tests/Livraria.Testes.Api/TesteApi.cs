using Livraria.Testes.Comum;
using NUnit.Framework;
using System.Net.Http;

namespace Livraria.Testes.Api
{
    class TesteApi
    {
        protected HttpClient Client = Contexto.Client;

        [TearDown]
        public void ExecutarAposCadaTeste()
        {
            GerenciadorLiteDb
                .RestaurarBackupComoBasePrincipal(
                    Contexto.DataBaseDirectory, Contexto.TestDbName, Contexto.DbName);
        }
    }
}
