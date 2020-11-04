using System;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;

namespace MeusJogos.Contexts.EmprestimoContext.Application.QueryResult
{
    public class JogosDisponiveisQueryResult
    {
        public Guid Id { get; set; }
        public string Jogo { get; set; }
    }
}