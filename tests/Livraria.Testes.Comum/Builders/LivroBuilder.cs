using LiteDB;
using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using System.Collections.Generic;

namespace Livraria.Testes.Comum.Builders
{
    public class LivroBuilder
    {
        private readonly string _diretorioDB;

        public LivroBuilder(string diretorioDB) => 
            _diretorioDB = diretorioDB;

        public Livro Instanciar() => new Livro
        {
            Titulo = "Livro Teste",
            NomeAutor = "Autor Teste",
            Preco = 59.99m,
            Categoria = Categoria.Fantasia
        };

        public Livro CriarNoDB()
        {
            var livro = Instanciar();

            using (var db = new LiteDatabase(_diretorioDB))
            {
                var objetoId = db.GetCollection<Livro>(LivroRepositorio.NomeColecao)
                    .Insert(livro);

                return livro;
            }
        }

        //public List<Livro> CriarListaNoDB()
        //{
        //    var livro = Instanciar();

        //    using (var db = new LiteDatabase(_diretorioDB))
        //    {
        //        var objetoId = db.GetCollection<Livro>(LivroRepositorio.NomeColecao)
        //            .Insert(livro);

        //        return livro;
        //    }
        //}

        //private List<Livro> InstanciarListaLivros(int quantidade)
        //{

        //}
    }
}
