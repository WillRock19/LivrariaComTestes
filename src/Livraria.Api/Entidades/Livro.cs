namespace Livraria.Api.Entidades
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeAutor { get; set; }
        public decimal Valor { get; set; }
        public Categoria Categoria { get; set; }
    }
}
