using FluentAssertions;
using NUnit.Framework;

namespace Livraria.Testes.Api.Funcionalidades.Catalogo
{
    class CatalogoControllerTestes : TesteApi
    {
        private const string PrefixoApi = "api/catalogo";

        [SetUp]
        public void Inicializar() { }

        [TestCase(TestName = "Get deve retornar BadRequest caso livroId não seja informado.")]
        public void DeveRetornarBadRequestCasoLivroIdNaoSejaInformado()
        {
            false.Should().BeTrue();
        }

        [TestCase(TestName = "Get deve retornar NotFound caso livro não seja encontrado.")]
        public void DeveRetornarNotFoundCasoLivroNaoSejaEncontrado()
        {
            false.Should().BeTrue();
        }

        [TestCase(TestName = "Get deve retornar livro a partir do livroId.")]
        public void DeveRetornarLivroAoReceberLivroId()
        {
            false.Should().BeTrue();
        }

        [TestCase(TestName = "Get deve retornar lista de livros do repositório.")]
        public void DeveRetornarListaLivros()
        {
            false.Should().BeTrue();
        }
    }
}
