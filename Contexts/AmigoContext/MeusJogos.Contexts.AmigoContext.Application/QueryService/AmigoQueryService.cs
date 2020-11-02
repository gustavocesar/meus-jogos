using MeusJogos.Contexts.AmigoContext.Application.QueryResult;
using MeusJogos.Contexts.AmigoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace MeusJogos.Contexts.AmigoContext.Application.QueryService
{
    public class AmigoQueryService : IAmigoQueryService
    {
        private readonly DataContext _context;

        public AmigoQueryService(DataContext context)
        {
            _context = context;
        }

        public ICollection<AmigoQueryResult> GetAmigos()
        {
            var amigos = _context.Amigos;
            var list = new List<AmigoQueryResult>();

            foreach (var amigo in amigos)
            {
                list.Add(new AmigoQueryResult
                {
                    Nome = amigo.Nome?.ToString(),
                    Celular = amigo.Celular?.ToString()
                });
            }

            return list;
        }
    }
}

