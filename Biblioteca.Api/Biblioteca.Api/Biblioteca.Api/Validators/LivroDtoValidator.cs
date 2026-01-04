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

            RuleFor(l => l.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero")
                .PrecisionScale(18, 2, true).WithMessage("O preço deve ter no máximo 18 digitos e 2 casas decimais");

            RuleFor(l => l.Editora)
                .MaximumLength(150).WithMessage("O nome da editora não deve ser maior do que {MaxLength} caracteres");

            RuleFor(l => l.EmailAutor)
                .NotEmpty().WithMessage("o email do autor é obrigatório")
                .EmailAddress().WithMessage("Informe um email válido");
        }
    }
}
