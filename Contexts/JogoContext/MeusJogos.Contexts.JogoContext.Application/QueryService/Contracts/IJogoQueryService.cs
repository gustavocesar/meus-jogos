using MeusJogos.Contexts.JogoContext.Application.QueryResult;
using System;
using System.Collections.Generic;

namespace MeusJogos.Contexts.JogoContext.Application.QueryService.Contracts
{
    public interface IJogoQueryService
    {
        JogoQueryResult GetJogo(Guid id);
        ICollection<JogoQueryResult> GetJogos();
    }
}
