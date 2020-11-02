using MeusJogos.SharedKernel.Domain.ValueObjects;

namespace MeusJogos.Contexts.AmigoContext.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeiroNome, string sobreNome)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;

            if (string.IsNullOrEmpty(PrimeiroNome))
                AddNotification("Nome.PrimeiroNome", "Nome inválido");

            if (string.IsNullOrEmpty(SobreNome))
                AddNotification("Nome.SobreNome", "Sobrenome inválido");
        }

        public override string ToString()
        {
            return $"{PrimeiroNome} {SobreNome}";
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }
    }
}