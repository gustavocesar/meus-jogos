using MeusJogos.Contexts.AmigoContext.Domain.ValueObjects;
using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeusJogos.Contexts.AmigoContext.Tests
{
    [TestClass]
    public class AmigoTest
    {
        [TestInitialize]
        public void Inicializar()
        {
        }

        [TestMethod]
        public void TestAmigoValido()
        {
            var nome = new Nome("Paulo", "Gustavo");
            var celular = new Celular("62", "998316669");
            var amigo = new Amigo(nome, celular);

            Assert.IsTrue(amigo.Valid);
        }

        [TestMethod]
        public void TestAmigoSemNome()
        {
            var nome = new Nome("", "");
            var celular = new Celular("62", "998316669");
            var amigo = new Amigo(nome, celular);

            Assert.IsTrue(amigo.Invalid);
        }

        [TestMethod]
        public void TestAmigoSemCelular()
        {
            var nome = new Nome("Paulo", "Gustavo");
            var celular = new Celular("", "");
            var amigo = new Amigo(nome, celular);

            Assert.IsTrue(amigo.Invalid);
        }
    }
}
