using MeusJogos.SharedKernel.Domain.ValueObjects;

namespace MeusJogos.Contexts.JogoContext.Domain.ValueObjects
{
    public class Titulo : ValueObject
    {
        public Titulo(string nome)
        {
            Nome = nome;

            if (string.IsNullOrEmpty(Nome))
                AddNotification("Titulo.Nome", "Nome inválido");
        }

        public string Nome { get; private set; }
    }
}