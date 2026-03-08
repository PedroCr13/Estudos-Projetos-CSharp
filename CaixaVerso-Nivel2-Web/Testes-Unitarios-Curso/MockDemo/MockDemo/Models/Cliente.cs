using FluentValidation;
using MockDemo.Core;

namespace MockDemo.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }

        public Cliente(string nome, string sobrenome, DateTime dataNascimento, string email)
        { 
            this.Nome = nome;
            this.SobreNome = sobrenome;
            this.DataNascimento = dataNascimento;
            this.Email = email;
        }

        public bool EhValido()
        {
            return new ClienteValidacao().Validate(this).IsValid;
        }

        // Validações utilizando extenção FluentValidation
        public class ClienteValidacao : AbstractValidator<Cliente>
        {
            public ClienteValidacao()
            {
                RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome.")
                    .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

                RuleFor(c => c.SobreNome)
                    .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o sobrenome.")
                    .Length(2, 150).WithMessage("O sobrenome deve ter entre 2 e 150 caracteres");

                RuleFor(c => c.DataNascimento)
                    .NotEmpty()
                    .Must(HaveMinimumAge)
                    .WithMessage("O cliente deve ter 18 anos ou mais.");

                RuleFor(c => c.Email)
                    .NotEmpty()
                    .EmailAddress();
            }

            public static bool HaveMinimumAge(DateTime birthDate)
            {
                return birthDate <= DateTime.Now.AddYears(-18);
            }
        }
    }
}
