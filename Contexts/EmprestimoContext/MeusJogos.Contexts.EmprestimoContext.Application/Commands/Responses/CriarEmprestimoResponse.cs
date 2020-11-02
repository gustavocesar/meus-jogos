using System;
using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using MeusJogos.Contexts.JogoContext.Domain.Entities;

namespace MeusJogos.Contexts.EmprestimoContext.Application.Response
{
    public class CriarEmprestimoResponse
    {
        public Guid Id { get; set; }
        public Amigo Amigo { get; set; }
        public Jogo Jogo { get; set; }
    }
}