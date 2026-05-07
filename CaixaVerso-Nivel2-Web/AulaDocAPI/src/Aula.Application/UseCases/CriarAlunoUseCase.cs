using Aula.Application.Presenters;
using Aula.Application.Requests;
using Aula.Application.Validators;
using Aula.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Camada Aplicação: é a ponte entre a camada de usuário, a externa e o dominio
    não deve ser afetada por mudanças externas (banco, UI, etc)

    FluentValidation: biblioteca, adicionar extensão na camada de application
    Abstrair o código de validação da entidade
    encapsular validações (campo nulo, vazio, qtde caracteres, etc)
*/

namespace Aula.Application.UseCases
{
    public class CriarAlunoUseCase : ICriarAlunoUseCase
    {
        // Injeção de dependência

        // adicionada na program, quando alguém solicitar um IValidator<CriarAlunoRequest>
        // será entregue automaticamente sem precisar instanciar

        // a injeção de dependencia é um padrão de design 
        // que permite que uma classe receba suas depedências de fora
        // ela não precisa se preocupar em instanciar internamente as classes das quais depende.

        // Fluxo:
        // 1 registra a dependência na Program.cs
        // 2 o container guarda essa configuração
        // 3 quando a classe CriarAlunoUseCase é instaciada, o container injeta o CriarAlunoValidator
        // 4 o handler usa o validator para verificar o request

        private readonly IValidator<CriarAlunoRequest> _validator;

        // O container de DI injeta automaticamente a implementação registrada na program(CriarAlunoValidator).
        // desta forma esta classe não precisa saber como criar o validador, apenas usa.
        public CriarAlunoUseCase(IValidator<CriarAlunoRequest> validator)
        {
            _validator = validator;
        }

        // cria o aluno
        public async Task<DefaultResponse<AlunoPresenter>> Handle(CriarAlunoRequest request)
        {
            // todos os atributos vieram preenchidos
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                // Criar entidade para retornar os erros.
                // não retornar exceção, pois o erro está sendo tratado.
                // conseiderar exceção quando algo não é previsto.

                return new DefaultResponse<AlunoPresenter>(validation.Errors.Select(x => x.ErrorMessage));
            }

            // buscar endereço pelo CEP

            // Criar entidade
            var aluno = new Aluno
            { 
                Id = 10,
                Nome = request.Nome,
                Email = request.Email,
                Cep = request.Cep,
                Uf = "MG",
                Bairro = "Centro"
            };

            // validar se mora em MG
            if (!aluno.AlunoMoraEmMinasGerais()) 
            {
                return new DefaultResponse<AlunoPresenter>("Aluno não mora em Minas Gerais");
            }

            // Salva no BD

            return new DefaultResponse<AlunoPresenter>(AlunoPresenter.AdaptToPresenter(aluno));
        }
    }
}
