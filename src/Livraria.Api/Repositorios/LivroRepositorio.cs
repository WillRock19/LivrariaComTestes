using Livraria.Api.Entidades;

namespace Livraria.Api.Repositorios
{
    public class LivroRepositorio : Repositorio<Livro>
    {
        public const string NomeColecao = "Livros";

        public LivroRepositorio(string diretorioCompletoBD)
            : base(diretorioCompletoBD, NomeColecao) { }
    }
}
