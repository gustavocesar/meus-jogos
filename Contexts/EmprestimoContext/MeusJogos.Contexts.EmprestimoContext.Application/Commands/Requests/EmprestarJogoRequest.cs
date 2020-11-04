using System;

namespace MeusJogos.Contexts.EmprestimoContext.Application.Requests
{
    public class EmprestarJogoRequest
    {
        public Guid AmigoId { get; set; }
        public Guid JogoId { get; set; }
    }
}