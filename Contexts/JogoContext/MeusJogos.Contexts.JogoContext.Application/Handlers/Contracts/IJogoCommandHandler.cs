using MeusJogos.Contexts.JogoContext.Application.Requests;
using MeusJogos.Contexts.JogoContext.Application.Responses;

namespace MeusJogos.Contexts.JogoContext.Application.Handlers.Contracts
{
    public interface IJogoCommandHandler
    {
        CriarJogoResponse Handle(CriarJogoRequest request);
        AlterarJogoResponse Handle(AlterarJogoRequest request);
    }
}