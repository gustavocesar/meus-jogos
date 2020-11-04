using MeusJogos.Contexts.JogoContext.Domain.Enums;
using MeusJogos.Contexts.JogoContext.Domain.ValueObjects;
using MeusJogos.SharedKernel.Domain.Entities;
using System;

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

        public override string ToString()
        {
            return $"{Titulo.Nome} ({Plataforma.ToString()})";
        }

        public void AlterarJogo(string titulo, EPlataforma plataforma)
        {
            Titulo.AlterarTitulo(titulo);
            Plataforma = plataforma;
        }

        public void ExcluirJogo(Guid id)
        {
        }
    }
}