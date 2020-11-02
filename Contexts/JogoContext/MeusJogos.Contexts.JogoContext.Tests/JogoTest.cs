using MeusJogos.Contexts.JogoContext.Domain.Entities;
using MeusJogos.Contexts.JogoContext.Domain.Enums;
using MeusJogos.Contexts.JogoContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeusJogos.Contexts.JogoContext.Tests
{
    [TestClass]
    public class JogoTest
    {
        [TestInitialize]
        public void Inicializar()
        {
        }

        [TestMethod]
        public void TestJogoValido()
        {
            var titulo = new Titulo("Doom 3");
            var jogo = new Jogo(titulo, EPlataforma.PS3);

            Assert.IsTrue(jogo.Valid);
        }

        [TestMethod]
        public void TestJogoInValido()
        {
            var titulo = new Titulo("");
            var jogo = new Jogo(titulo, EPlataforma.PS3);

            Assert.IsTrue(jogo.Invalid);
        }
    }
}
