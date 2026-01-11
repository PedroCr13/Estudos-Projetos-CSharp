using Biblioteca.Api.DTOs;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Biblioteca.Api.Validators
{
    public class EditoraDtoValidator : AbstractValidator<EditoraDTO>
    {
        public EditoraDtoValidator() 
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O nome da editora é obrigatório!")
                .MaximumLength(200).WithMessage("O nome da editora não deve passar de 200 caracteres.");

            RuleFor(e => e.Endereco)
                .MaximumLength(200).WithMessage("O endereço não deve passar de 200 caracteres.");

            RuleFor(e => e.Telefone)
                .MaximumLength(14).WithMessage("O telefone deve conter no máximo 14 caracteres.");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email da editora deve ser preenchido.")
                .EmailAddress().WithMessage("Informar um email válido");

        }
    }
}
