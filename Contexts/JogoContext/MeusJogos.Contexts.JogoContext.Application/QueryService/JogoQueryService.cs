using MeusJogos.Context.Application.QueryResult;
using MeusJogos.Context.Application.QueryService.Contracts;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace MeusJogos.Context.Application.QueryService
{
    public class JogoQueryService : IJogoQueryService
    {
        private readonly DataContext _context;

        public JogoQueryService(DataContext context)
        {
            _context = context;
        }

        public ICollection<JogoQueryResult> GetJogos()
        {
            var jogos = _context.Jogos;
            var list = new List<JogoQueryResult>();

            foreach (var jogo in jogos)
            {
                list.Add(new JogoQueryResult
                {
                    Jogo = jogo
                });
            }

            return list;
        }
    }
}

