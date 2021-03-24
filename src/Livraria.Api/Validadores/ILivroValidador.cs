using FluentValidation.Results;
using Livraria.Api.Entidades;

namespace Livraria.Api.Validadores
{
    public interface ILivroValidador
    {
        ValidationResult Validate(Livro instance);
    }
}
