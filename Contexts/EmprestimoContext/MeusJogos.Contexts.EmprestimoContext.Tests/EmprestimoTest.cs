using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using MeusJogos.Contexts.AmigoContext.Domain.ValueObjects;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using MeusJogos.Contexts.JogoContext.Domain.Enums;
using MeusJogos.Contexts.JogoContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;

namespace MeusJogos.Contexts.EmprestimoContext.Tests
{
    [TestClass]
    public class EmprestimoTest
    {
        [TestInitialize]
        public void Inicializar()
        {
        }

        [TestMethod]
        public void TestEmprestimoValido()
        {
            var nome = new Nome("Paulo", "Gustavo");
            var celular = new Celular("62", "998316669");
            var amigo = new Amigo(nome, celular);

            var titulo = new Titulo("Doom 3");
            var jogo = new Jogo(titulo, EPlataforma.PS3);

            var emprestimo = new Emprestimo(amigo, jogo);

            Assert.IsTrue(emprestimo.Valid);
        }

        [TestMethod]
        public void TestEmprestimoAmigoSemNome()
        {
            var nome = new Nome("", "");
            var celular = new Celular("62", "998316669");
            var amigo = new Amigo(nome, celular);

            var titulo = new Titulo("Doom 3");
            var jogo = new Jogo(titulo, EPlataforma.PS3);

            var emprestimo = new Emprestimo(amigo, jogo);

            Assert.IsTrue(emprestimo.Invalid);
        }

        [TestMethod]
        public void TestEmprestimoAmigoSemCelular()
        {
            var nome = new Nome("Paulo", "Gustavo");
            var celular = new Celular("", "");
            var amigo = new Amigo(nome, celular);

            var titulo = new Titulo("Doom 3");
            var jogo = new Jogo(titulo, EPlataforma.PS3);

            var emprestimo = new Emprestimo(amigo, jogo);

            Assert.IsTrue(emprestimo.Invalid);
        }

        [TestMethod]
        public void TestEmprestimoAmigoSemJogo()
        {
            var nome = new Nome("Paulo", "Gustavo");
            var celular = new Celular("", "");
            var amigo = new Amigo(nome, celular);

            var titulo = new Titulo("");
            var jogo = new Jogo(titulo, EPlataforma.PS3);

            var emprestimo = new Emprestimo(amigo, jogo);

            Assert.IsTrue(emprestimo.Invalid);
        }
    }
}
