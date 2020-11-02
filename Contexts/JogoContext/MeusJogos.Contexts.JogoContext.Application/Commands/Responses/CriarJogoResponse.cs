using System;
using MeusJogos.Contexts.JogoContext.Domain.Enums;

namespace MeusJogos.Contexts.JogoContext.Application.Responses
{
    public class CriarJogoResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public EPlataforma Plataforma { get; set; }
    }
}