using Dapper;
using Livraria.Api.Entidades;
using Livraria.Api.Infraestrutura.Sqls;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Api.Repositorios
{
    public class LivroRepositorio
    {
        private readonly string _connectionString;

        public LivroRepositorio(string connectionString) => 
            _connectionString = connectionString;

        public async Task<Livro> ObterLivro(int livroId)
        {
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                var resultado = await connection.QueryAsync<Livro>(LivroSql.ObterPorId, new
                {
                    LivroId = livroId
                });

                return resultado.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Livro>> ObterLivros()
        {
            using (IDbConnection connection = new SQLiteConnection(_connectionString)) 
            {
                var resultado = await connection.QueryAsync<Livro>(LivroSql.ObterTodos);
                return resultado;
            }
        }
    }
}
