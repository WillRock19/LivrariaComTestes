namespace Livraria.Api.Infraestrutura.Sqls
{
    public class LivroSql
    {
        public static string ObterTodos = "SELECT * FROM Livro";
        public static string ObterPorId = "SELECT * FROM Livro WHERE Id = @LivroId";
    }
}
