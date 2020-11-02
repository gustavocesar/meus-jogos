using MeusJogos.Contexts.JogoContext.Application.QueryResult;
using System.Collections.Generic;

namespace MeusJogos.Contexts.JogoContext.Application.QueryService.Contracts
{
    public interface IJogoQueryService
    {
        ICollection<JogoQueryResult> GetJogos();
    }
}
