using MeusJogos.Contexts.EmprestimoContext.Application.QueryResult;
using System.Collections.Generic;

namespace MeusJogos.Contexts.EmprestimoContext.Application.QueryService.Contracts
{
    public interface IEmprestimoQueryService
    {
        ICollection<EmprestimoQueryResult> GetEmprestimos();
        ICollection<JogosEmprestadosQueryResult> GetJogosEmprestados();
        ICollection<JogosDisponiveisQueryResult> GetJogosDisponiveis();
    }
}
