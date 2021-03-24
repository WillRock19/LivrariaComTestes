using FluentValidation.TestHelper;
using Livraria.Api.Validadores;
using Livraria.Testes.Unidade.Configurations;
using NUnit.Framework;

namespace Livraria.Testes.Unidade.Specs.Validadores
{
    internal class LivroValidadorTest : TestBase
    {
        protected LivroValidador _validator;

        [SetUp]
        public void SetUp() 
        {
            _validator = _autoFake.Resolve<LivroValidador>();
        }

        class LivroValidadorTestesInvalidos : LivroValidadorTest 
        {
            [TestCase("")]
            [TestCase((string)null)]
            public void DeveSerInvalidoCasoNomeDoAutorSejaNuloOuVazio(string nomeAutor)
            {
                _validator.ShouldHaveValidationErrorFor(x => x.NomeAutor, nomeAutor)
                    .WithErrorMessage("Nome do autor não pode ser vazio");
            }

            [TestCase(-10)]
            [TestCase(-5)]
            [TestCase(-1)]
            [TestCase(0)]
            public void DeveSerInvalidoCasoPrecoDoLivroSejaMenorOuIgualZero(int preco)
            {
                _validator.ShouldHaveValidationErrorFor(x => x.Preco, preco)
                    .WithErrorMessage("Preço deve ser maior que zero");
            }

            [TestCase("")]
            [TestCase((string)null)]
            public void DeveSerInvalidoCasoTituloSejaNuloOuVazio(string titulo)
            {
                _validator.ShouldHaveValidationErrorFor(x => x.Titulo, titulo)
                    .WithErrorMessage("O título do livro não pode ser vazio");
            }
        }

        class LivroValidadorTestesValidos : LivroValidadorTest
        {
            [TestCase("testName")]
            [TestCase("Test Name")]
            [TestCase("Teste Name 23")]
            public void DeveSerValidoCasoAutorPossuaNomesComOuSemEspaços(string nome)
            {
                _validator.ShouldNotHaveValidationErrorFor(x => x.NomeAutor, nome);
            }

            [TestCase(1)]
            [TestCase(5)]
            [TestCase(10)]
            public void DeveSerValidoCasoPrecoSejaMaiorQueZero(int preco)
            {
                _validator.ShouldNotHaveValidationErrorFor(x => x.Preco, preco);
            }

            [TestCase("testName")]
            [TestCase("Test Name")]
            [TestCase("Teste Name 23")]
            public void DeveSerValidoCasoTituloossuaNomesComOuSemEspaçosENumeros(string titulo)
            {
                _validator.ShouldNotHaveValidationErrorFor(x => x.Titulo, titulo);
            }
        }
    }
}
