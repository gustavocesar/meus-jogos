using System;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;

namespace MeusJogos.Contexts.EmprestimoContext.Application.QueryResult
{
    public class JogosEmprestadosQueryResult
    {
        public Guid Id { get; set; }
        public string Amigo { get; set; }
        public string Jogo { get; set; }
        public DateTime DataEmprestimo { get; set; }
    }
}