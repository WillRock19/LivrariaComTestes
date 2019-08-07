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

        public List<Livro> CriarListaNoDB(int quantidade)
        {
            var livros = InstanciarListaLivros(quantidade);
            var livrosComIds = new List<Livro>();

            using (var db = new LiteDatabase(_diretorioDB))
            {
                foreach (var livro in livros)
                {
                    db.GetCollection<Livro>(LivroRepositorio.NomeColecao)
                        .Insert(livro);

                    livrosComIds.Add(livro);
                }

                return livrosComIds;
            }
        }

        private List<Livro> InstanciarListaLivros(int quantidade)
        {
            var livros = new List<Livro>();

            for (var index = 0; index <= quantidade; index++)
            {
                livros.Add(new Livro
                {
                    Titulo = $"Livro Teste {index}",
                    NomeAutor = $"Autor Teste {index}",
                    Preco = 9.99m * index,
                    Categoria = Categoria.Fantasia
                });
            }

            return livros;
        }
    }
}
