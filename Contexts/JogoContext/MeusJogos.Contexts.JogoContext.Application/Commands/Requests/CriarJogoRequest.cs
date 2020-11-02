using MeusJogos.Contexts.JogoContext.Domain.Enums;

namespace MeusJogos.Contexts.JogoContext.Application.Requests
{
    public class CriarJogoRequest
    {
        public string Titulo { get; set; }
        public EPlataforma Plataforma { get; set; }
    }
}