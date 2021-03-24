using FluentValidation;
using FluentValidation.Results;
using Livraria.Api.Entidades;

namespace Livraria.Api.Validadores
{
    public class LivroValidador : AbstractValidator<Livro>, ILivroValidador
    {
        public LivroValidador()
        {
            RuleFor(x => x.NomeAutor)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Nome do autor não pode ser vazio");

            RuleFor(x => x.Preco)
                .Cascade(CascadeMode.Stop)
                .Must(preco => preco > 0)
                .WithMessage("Preço deve ser maior que zero");

            RuleFor(x => x.Titulo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O título do livro não pode ser vazio");
        }

        public ValidationResult Validate(Livro livro)
        {
            return base.Validate(livro);
        }
    }
}
