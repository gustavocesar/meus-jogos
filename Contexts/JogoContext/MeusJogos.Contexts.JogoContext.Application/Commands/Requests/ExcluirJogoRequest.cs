using System;
using MeusJogos.Contexts.JogoContext.Domain.Enums;

namespace MeusJogos.Contexts.JogoContext.Application.Requests
{
    public class ExcluirJogoRequest
    {
        public Guid Id { get; set; }
    }
}