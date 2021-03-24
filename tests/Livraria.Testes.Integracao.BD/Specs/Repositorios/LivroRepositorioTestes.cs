using FluentAssertions;
using LiteDB;
using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using Livraria.Testes.Comum.Builders;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Testes.Integracao.BD.Specs.Repositorios
{
    class LivroRepositorioTestes : TesteIntegracao
    {
        private LivroRepositorio _livroRepositorio;

        [SetUp]
        public void Inicializar() => 
            _livroRepositorio = new LivroRepositorio(Contexto.DbFullEndpoint);

        [TestCase(TestName = "Deve salvar livros dentro da base de dados")]
        public void DeveSalvarLivroNaBaseDeDados()
        {
            //arrange
            var livro = new Livro()
            {
                Titulo = "O teste do apanhador de senteio",
                NomeAutor = "Autor dos testes",
                Preco = 99.98m,
                Categoria = Categoria.Fantasia
            };

            //action
            _livroRepositorio.Salvar(livro);

            //assert
            using (var db = new LiteDatabase(Contexto.DbFullEndpoint))
            {
                var livros = db.GetCollection<Livro>(LivroRepositorio.NomeColecao)
                    .FindAll().ToList();
                livros.LastOrDefault().Should().BeEquivalentTo(livro);
            }
        }

        [TestCase(TestName = "Deve obter lista de livros da base de dados")]
        public void DeveObterListaDeLivros()
        {
            //arrange
            var livrosCriados = new LivroBuilder(Contexto.DbFullEndpoint).CriarListaNoDB(5);
            
            //action
            var livrosRecuperados = _livroRepositorio.ObterTodos();

            //assert
            TodosLivrosCriadosForamRecuperados(livrosCriados, livrosRecuperados)
                .Should().BeTrue();
        }

        [TestCase(TestName = "Deve obter livro por livroId")]
        public void DeveObterLivroPorId()
        {
            //arrange
            var livroCriado = new LivroBuilder(Contexto.DbFullEndpoint).CriarNoDB();
            
            //action
            var livroRecuperado = _livroRepositorio.ObterPorId(livroCriado.Id);

            //assert
            livroRecuperado.Should().BeEquivalentTo(livroCriado);
        }

        private bool TodosLivrosCriadosForamRecuperados(List<Livro> livrosCriados, List<Livro> livrosRecuperados)
        {
            return livrosCriados.Except(livrosRecuperados).Any();
        }
    }
}
