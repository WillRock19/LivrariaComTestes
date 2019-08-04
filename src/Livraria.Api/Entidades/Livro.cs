namespace Livraria.Api.Entidades
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NomeAutor { get; set; }
        public decimal Preco { get; set; }
        public Categoria Categoria { get; set; }
    }
}
