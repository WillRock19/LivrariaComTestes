using FakeItEasy;
using FluentAssertions;
using FluentValidation.Results;
using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using Livraria.Api.Servicos;
using Livraria.Api.Validadores;
using Livraria.Testes.Unidade.Configurations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Testes.Unidade.Specs.Serviços
{
    internal class ServicoCatalogoTest : TestBase
    {
        private ServicoCatalogo _servicoCatalogo;
        private ILivroValidador _livroValidator;
        private IRepositorio<Livro> _livroRepositorio;

        [SetUp]
        public void SetUp() 
        {
            _livroValidator = A.Fake<ILivroValidador>();
            _livroRepositorio = A.Fake<IRepositorio<Livro>>();

            _servicoCatalogo = new ServicoCatalogo(_livroRepositorio, _livroValidator);
        }

        class CadastrarNoCatalogo : ServicoCatalogoTest 
        {
            [Test]
            public void DeveValidarLivroRecebidoViaParametro() 
            {
                //arrage
                var livro = A.Fake<Livro>();

                //action
                _servicoCatalogo.CadastrarNoCatalogo(livro);

                //assert
                A.CallTo(() => _livroValidator.Validate(livro))
                    .MustHaveHappened();
            }

            [Test]
            public void DeveRetornarListaDeErrosCasoLivroSejaInvalido()
            {
                //arrange
                var livro = A.Fake<Livro>();
                var listaErros = new List<string>() { "erro1" };

                //Mockando retorno do Validate com a biblioteca FakeItEasy
                A.CallTo(() => _livroValidator.Validate(livro))
                    .Returns(CriarResultMockado(listaErros));

                //action
                var retorno = _servicoCatalogo.CadastrarNoCatalogo(livro);

                //assert
                retorno.Should().BeEquivalentTo(listaErros);
            }

            [Test]
            public void NãoDeveSalvarLivroNoRepositórioCasoLivroSejaInvalido()
            {
                //arrange
                var livro = A.Fake<Livro>();
                var listaErros = new List<string>() { "erro1" };

                A.CallTo(() => _livroValidator.Validate(livro))
                    .Returns(CriarResultMockado(listaErros));

                //action
                _servicoCatalogo.CadastrarNoCatalogo(livro);

                //assert
                A.CallTo(() => _livroRepositorio.Salvar(livro))
                    .MustNotHaveHappened();
            }

            [Test]
            public void DeveSalvarLivroNoRepositórioCasoLivroSejaValido()
            {
                //arrange
                var livro = A.Fake<Livro>();

                A.CallTo(() => _livroValidator.Validate(livro))
                    .Returns(CriarResultMockado(new List<string>()));

                //action
                _servicoCatalogo.CadastrarNoCatalogo(livro);

                //assert
                A.CallTo(() => _livroRepositorio.Salvar(livro))
                    .MustHaveHappened();
            }

            [Test]
            public void DeveRetornarListaVaziaCasoLivroSejaValido() 
            {
                //arrange
                var livro = A.Fake<Livro>();

                A.CallTo(() => _livroValidator.Validate(livro))
                    .Returns(CriarResultMockado(new List<string>()));

                //action
                var retorno = _servicoCatalogo.CadastrarNoCatalogo(livro);

                //assert
                retorno.Should().BeEmpty();
            }

            private ValidationResult CriarResultMockado(List<string> errors) 
            {
                var validationFailures = errors.Select(errorMessage =>
                    new ValidationFailure("property_test", errorMessage));

                return new ValidationResult(validationFailures);
            }
        }
    }
}
