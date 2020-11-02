using MeusJogos.Contexts.JogoContext.Domain.Enums;
using MeusJogos.Contexts.JogoContext.Domain.ValueObjects;
using MeusJogos.SharedKernel.Domain.Entities;

namespace MeusJogos.Contexts.JogoContext.Domain.Entities
{
    public class Jogo : Entity
    {
        public Jogo()
        {
        }
        
        public Jogo(Titulo titulo, EPlataforma plataforma)
        {
            Titulo = titulo;
            Plataforma = plataforma;

            AddNotifications(titulo);
        }

        public Titulo Titulo { get; private set; }
        public EPlataforma Plataforma { get; private set; }
    }
}