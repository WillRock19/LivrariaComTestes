using FluentAssertions;
using Livraria.Testes.Aceitacao.Paginas.Home;
using NUnit.Framework;

namespace Livraria.Testes.Aceitacao.Specs
{
    class PaginaHomeTestes : TesteAceitacao
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
            //assert
            _home.BannerEstaVisivel().Should().BeTrue();
        }

        [TestCase(TestName = "Deve conseguir navegar para pagina de conteúdo")]
        public void DeveNavegarParaPaginaDeConteudo()
        {
            //action
            var paginaConteudo = _home.NavegarPaginaConteudo();
            
            //assert
            paginaConteudo.ObterUrlAtualDoNavegador().Should().Contain("/Home/Privacy");
        }

        [TestCase(TestName = "Deve exibir mensagem provocativa na tela de conteúdo")]
        public void DeveExibirMensagemProvocativaNaTela()
        {
            var subPaginaConteudo = new SubPaginaConteudo();
            var mensagemEsperada = "Tá na hora de colocar ALGUMA COISA neste site, né? :p";

            subPaginaConteudo.Navegar();
            var mensagem = subPaginaConteudo.ObterMensagemProvocativa();

            mensagem.Should().Be(mensagemEsperada);
        }
    }
}
