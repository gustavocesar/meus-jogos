using MeusJogos.SharedKernel.Domain.ValueObjects;

namespace MeusJogos.Contexts.AmigoContext.Domain.ValueObjects
{
    public class Celular : ValueObject
    {
        public Celular(string ddd, string numero)
        {
            Ddd = ddd;
            Numero = numero;

            if (string.IsNullOrEmpty(Ddd))
                AddNotification("Celular.Ddd", "Ddd inválido");

            if (Ddd.Length != 2)
                AddNotification("Celular.Ddd", "Ddd deve possuir 2 dígitos");

            if (string.IsNullOrEmpty(Numero))
                AddNotification("Celular.Numero", "Número inválido");
                
            if (Numero.Length != 9)
                AddNotification("Celular.Numero", "Número deve possuir 9 dígitos");
        }

        public override string ToString()
        {
            return $"({Ddd}) {Numero}";
        }

        public string Ddd { get; private set; }
        public string Numero { get; private set; }
    }
}