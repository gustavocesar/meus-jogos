using MeusJogos.Contexts.AmigoContext.Domain.ValueObjects;
using MeusJogos.SharedKernel.Domain.Entities;

namespace MeusJogos.Contexts.AmigoContext.Domain.Entities
{
    public class Amigo : Entity //PessoaFisica
    {
        public Amigo()
        {
        }
        
        public Amigo(Nome nome, Celular celular)// : base(nome)
        {
            Nome = nome;
            Celular = celular;

            AddNotifications(nome, celular);
        }

        public Nome Nome { get; private set; }
        public Celular Celular { get; private set; }
    }
}