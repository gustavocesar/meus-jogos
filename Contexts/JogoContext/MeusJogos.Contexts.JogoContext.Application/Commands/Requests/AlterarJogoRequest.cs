using System;
using MeusJogos.Contexts.JogoContext.Domain.Enums;

namespace MeusJogos.Contexts.JogoContext.Application.Requests
{
    public class AlterarJogoRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public EPlataforma Plataforma { get; set; }
    }
}