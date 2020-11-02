using MeusJogos.Context.Application.QueryResult;
using System.Collections.Generic;

namespace MeusJogos.Context.Application.QueryService.Contracts
{
    public interface IJogoQueryService
    {
        ICollection<JogoQueryResult> GetJogos();
    }
}
