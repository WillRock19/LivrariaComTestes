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

        [TestCase(TestName = "Deve exibir o banner do evento na tela")]
        public void DeveExibirBannerDoEvento()
        {
            _home.BannerEstaVisivel().Should().BeTrue();
        }

        [TestCase(TestName = "Deve exibir mensagem provocativa na tela")]
        public void DeveExibirMensagemProvocativaNaTela()
        {
            var mensagemEsperada = "Tá na hora de colocar ALGUMA COISA neste site, né? :p";
            var mensagem = _home.ObterMensagemProvocativa();

            mensagem.Should().Be(mensagemEsperada);
        }
    }
}
