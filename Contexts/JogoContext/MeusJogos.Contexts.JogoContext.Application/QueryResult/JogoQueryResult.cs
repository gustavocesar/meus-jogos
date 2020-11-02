using System;
using MeusJogos.Contexts.JogoContext.Domain.Entities;

namespace MeusJogos.Contexts.JogoContext.Application.QueryResult
{
    public class JogoQueryResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Plataforma { get; set; }
    }
}