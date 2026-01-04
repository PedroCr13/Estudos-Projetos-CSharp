using Biblioteca.Api.DTOs;
using FluentValidation;

namespace Biblioteca.Api.Validators
{
    public class AutorDtoValidator : AbstractValidator<AutorDTO>
    {
        public AutorDtoValidator() 
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O nome do autor é obrigatório")
                .Length(3, 100).WithMessage("O nome do autor deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("O email do autor deve ser preenchido")
                .EmailAddress();

            RuleFor(a => a.Observacao)
                .MaximumLength(2000).WithMessage("A observcação não deve passar de {MaxLength} caracteres");
        }
    }
}
