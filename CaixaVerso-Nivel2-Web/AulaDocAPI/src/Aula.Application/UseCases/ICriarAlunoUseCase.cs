using Aula.Application.Presenters;
using Aula.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Application.UseCases
{
    public interface ICriarAlunoUseCase
    {
        Task<DefaultResponse<AlunoPresenter>> Handle(CriarAlunoRequest request);
    }
}
