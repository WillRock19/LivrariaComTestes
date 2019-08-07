using FluentAssertions;
using LiteDB;
using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using Livraria.Testes.Comum.Builders;
using NUnit.Framework;
using System.Linq;

namespace Livraria.Testes.Integracao.Repositorios
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
            var livro = new Livro()
            {
                Titulo = "O teste do apanhador de senteio",
                NomeAutor = "Autor dos testes",
                Preco = 99.98m,
                Categoria = Categoria.Fantasia
            };

            _livroRepositorio.Salvar(livro);

            using (var db = new LiteDatabase(Contexto.DbFullEndpoint))
            {
                var livros = db.GetCollection<Livro>(LivroRepositorio.NomeColecao).FindAll().ToList();
                livros.LastOrDefault().Should().BeEquivalentTo(livro);
            }
        }

        [TestCase(TestName = "Deve obter lista de livros da base de dados")]
        public void DeveObterListaDeLivros()
        {
            false.Should().BeTrue();
        }

        [TestCase(TestName = "Deve obter livro por livroId")]
        public void DeveObterLivroPorId()
        {
            var livroCriado = new LivroBuilder(Contexto.DbFullEndpoint).CriarNoDB();
            var livroRecuperado = _livroRepositorio.ObterPorId(livroCriado.Id);

            livroRecuperado.Should().BeEquivalentTo(livroCriado);
        }
    }
}
