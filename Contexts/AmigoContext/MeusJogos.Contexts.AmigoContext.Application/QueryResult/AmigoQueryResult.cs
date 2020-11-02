using System;
using MeusJogos.Contexts.AmigoContext.Domain.Entities;

namespace MeusJogos.Contexts.AmigoContext.Application.QueryResult
{
    public class AmigoQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
    }
}