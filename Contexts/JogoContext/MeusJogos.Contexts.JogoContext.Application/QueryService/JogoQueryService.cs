using MeusJogos.Contexts.JogoContext.Application.QueryResult;
using MeusJogos.Contexts.JogoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeusJogos.Contexts.JogoContext.Application.QueryService
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
            var jogos = _context.Jogos.ToList();
            var list = new List<JogoQueryResult>();

            foreach (var jogo in jogos)
            {
                list.Add(new JogoQueryResult
                {
                    Titulo = jogo.Titulo?.Nome,
                    Plataforma = jogo.Plataforma.ToString()
                });
            }

            return list;
        }
    }
}

