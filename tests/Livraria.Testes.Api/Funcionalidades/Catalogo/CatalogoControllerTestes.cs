using FluentAssertions;
using Livraria.Api.Entidades;
using Livraria.Testes.Comum.Builders;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Livraria.Testes.Api.Funcionalidades.Catalogo
{
    class CatalogoControllerTestes : TesteApi
    {
        private const string PrefixoApi = "api/catalogo";

        [SetUp]
        public void Inicializar() { }

        [TestCase(TestName = "Obter deve retornar 'Requisição ruim' caso livroId não seja informado.")]
        public async Task DeveRetornarBadRequestCasoLivroIdNaoSejaInformado()
        {
            var resposta = await Client.GetAsync($"{PrefixoApi}");
            var objetoRetorno = await ObterObjetoRetornado(resposta);

            resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            objetoRetorno.Dados.Should().BeNull();
            objetoRetorno.Sucesso.Should().BeFalse();
            objetoRetorno.Notificacoes.Should().Contain(x => x == "Favor, informar o livroId do livro desejado");
        }

        [TestCase(TestName = "Obter deve retornar 'Não encontrado' caso livro não seja encontrado.")]
        public async Task DeveRetornarNotFoundCasoLivroNaoSejaEncontrado()
        {
            var livroId = 999;
            var resposta = await Client.GetAsync($"{PrefixoApi}?livroId={livroId}");
            var objetoRetorno = await ObterObjetoRetornado(resposta);

            resposta.StatusCode.Should().Be(HttpStatusCode.NotFound);

            objetoRetorno.Dados.Should().BeNull();
            objetoRetorno.Sucesso.Should().BeFalse();
            objetoRetorno.Notificacoes.Should().Contain(x => x == $"Livro {livroId} não foi encontrado!");
        }

        [TestCase(TestName = "Obter deve retornar livro a partir do livroId.")]
        public async Task DeveRetornarLivroAoReceberLivroId()
        {
            var livroDesejado = new LivroBuilder(Contexto.DbFullEndpoint).CriarNoDB();

            var resposta = await Client.GetAsync($"{PrefixoApi}?livroId={livroDesejado.Id}");
            var objetoRetorno = await ObterObjetoRetornado(resposta);
            var livroRetornado = ObterDadosLivro(objetoRetorno.Dados);

            resposta.StatusCode.Should().Be(HttpStatusCode.OK);

            objetoRetorno.Dados.Should().NotBeNull();
            objetoRetorno.Sucesso.Should().BeTrue();
            objetoRetorno.Notificacoes.Should().BeNullOrEmpty();

            livroRetornado.Should().BeEquivalentTo(livroDesejado);
        }

        [TestCase(TestName = "Obter deve retornar lista de livros do repositório.")]
        public async Task DeveRetornarListaLivros()
        {
            var resposta = await Client.GetAsync($"{PrefixoApi}/livros");
            var objetoRetorno = await ObterObjetoRetornado(resposta);
            var listaLivros = ObterDadosListaLivros(objetoRetorno.Dados);

            resposta.StatusCode.Should().Be(HttpStatusCode.OK);

            objetoRetorno.Dados.Should().NotBeNull();
            objetoRetorno.Sucesso.Should().BeTrue();
            objetoRetorno.Notificacoes.Should().BeNullOrEmpty();
        }

        public async Task<ResultadoApi> ObterObjetoRetornado(HttpResponseMessage response) => JsonConvert.DeserializeObject<ResultadoApi>(await response.Content.ReadAsStringAsync());

        public Livro ObterDadosLivro(object dados) =>
            JsonConvert.DeserializeObject<Livro>(dados.ToString());

        public List<Livro> ObterDadosListaLivros(object dados) =>
            JsonConvert.DeserializeObject<List<Livro>>(dados.ToString());
    }
}
