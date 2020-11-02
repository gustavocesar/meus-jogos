using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using MeusJogos.SharedKernel.Domain.Entities;
using System;

namespace MeusJogos.Contexts.EmprestimoContext.Domain.Entities
{
    public class Emprestimo : Entity
    {
        public Emprestimo()
        {
        }

        public Emprestimo(Amigo amigo, Jogo jogo)
        {
            Amigo = amigo;
            Jogo = jogo;
            DataEmprestimo = DateTime.Now;

            AddNotifications(amigo, jogo);
        }

        public Amigo Amigo { get; private set; }
        public Jogo Jogo { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
    }
}