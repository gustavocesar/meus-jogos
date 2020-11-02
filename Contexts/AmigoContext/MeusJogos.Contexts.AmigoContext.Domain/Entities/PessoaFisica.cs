using MeusJogos.Contexts.AmigoContext.Domain.ValueObjects;
using MeusJogos.SharedKernel.Domain.Entities;

namespace MeusJogos.Contexts.AmigoContext.Domain.Entities
{
    public abstract class PessoaFisica : Entity
    {
        protected PessoaFisica(Nome nome)
        {
            Nome = nome;
        }

        public Nome Nome { get; private set; }
    }
}