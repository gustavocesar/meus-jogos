using MeusJogos.Contexts.AmigoContext.Application.QueryResult;
using System.Collections.Generic;

namespace MeusJogos.Contexts.AmigoContext.Application.QueryService.Contracts
{
    public interface IAmigoQueryService
    {
        ICollection<AmigoQueryResult> GetAmigos();
    }
}
