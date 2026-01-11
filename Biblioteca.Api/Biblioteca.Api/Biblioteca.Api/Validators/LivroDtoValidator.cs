using Biblioteca.Api.DTOs;
using FluentValidation;

namespace Biblioteca.Api.Validators
{
    public class LivroDtoValidator : AbstractValidator<LivroDTO>
    {
        public LivroDtoValidator()
        {
            RuleFor(l => l.Nome)
                .NotEmpty().WithMessage("O nome do livro é obrigatório")
                .Length(3, 100).WithMessage("O nome do livro deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(l => l.Edicao)
                .NotEmpty().WithMessage("A edição do livro é obrigatória")
                .MaximumLength(50).WithMessage("A edição não deve passar de {MaxLength} caracteres");

            RuleFor(l => l.NumeroPagina)
                .GreaterThan(0).WithMessage("O número de páginas deve ser maior que zero.");

            RuleFor(l => l.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero")
                .PrecisionScale(18, 2, true).WithMessage("O preço deve ter no máximo 18 digitos e 2 casas decimais");

            RuleFor(l => l.Id_editora)
                .GreaterThan(0).WithMessage("É necessário informar uma editora válida!");

            RuleFor(l => l.EmailAutor)
                .NotEmpty().WithMessage("O email do autor é obrigatório")
                .EmailAddress().WithMessage("Informe um email válido");
        }
    }
}
