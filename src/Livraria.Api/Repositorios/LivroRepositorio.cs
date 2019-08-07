using Livraria.Api.Entidades;

namespace Livraria.Api.Repositorios
{
    public class LivroRepositorio : Repositorio<Livro>
    {
        public const string NomeColecao = "Livros";

        public LivroRepositorio(string connectionString)
            : base(connectionString, NomeColecao) { }



        //public async Task<Livro> ObterLivro(int livroId)
        //{
        //    using (IDbConnection connection = new SQLiteConnection(_connectionString))
        //    {
        //        var resultado = await connection.QueryAsync<Livro>(LivroSql.ObterPorId, new
        //        {
        //            LivroId = livroId
        //        });

        //        return resultado.FirstOrDefault();
        //    }
        //}

        //public async Task<IEnumerable<Livro>> ObterLivros()
        //{
        //    using (IDbConnection connection = new SQLiteConnection(_connectionString)) 
        //    {
        //        var resultado = await connection.QueryAsync<Livro>(LivroSql.ObterTodos);
        //        return resultado;
        //    }
        //}
    }
}
