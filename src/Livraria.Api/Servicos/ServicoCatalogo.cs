using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using Livraria.Api.Validadores;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Api.Servicos
{
    public class ServicoCatalogo
    {
        private readonly IRepositorio<Livro> _repositorioLivros;
        private readonly ILivroValidador _validador;

        public ServicoCatalogo(IRepositorio<Livro> repositorioLivros, ILivroValidador validador)
        {
            _validador = validador;
            _repositorioLivros = repositorioLivros;
        }

        public List<string> CadastrarNoCatalogo(Livro livro) 
        {
            var result = _validador.Validate(livro);

            if (!result.IsValid)
                return result.Errors.Select(x => x.ErrorMessage).ToList();

            _repositorioLivros.Salvar(livro);
            return new List<string>();
        }
    }
}
