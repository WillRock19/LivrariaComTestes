using FluentAssertions;
using Livraria.Testes.Aceitacao.Paginas.Home;
using NUnit.Framework;

namespace Livraria.Testes.Aceitacao.Funcionalidades
{
    class ListarLivrosTestes : TesteAceitacao
    {
        private PaginaHome _home;

        [SetUp]
        public void Inicializar()
        {
            _home = new PaginaHome();
            _home.Navegar();
        }

        [TestCase(TestName = "Tste")]
        public void T()
        {
            false.Should().BeTrue();
        }
    }
}
