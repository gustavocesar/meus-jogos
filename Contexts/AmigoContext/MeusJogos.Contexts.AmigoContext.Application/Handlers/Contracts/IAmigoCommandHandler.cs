using MeusJogos.Contexts.AmigoContext.Application.Requests;
using MeusJogos.Contexts.AmigoContext.Application.Responses;

namespace MeusJogos.Contexts.AmigoContext.Application.Handlers.Contracts
{
    public interface IAmigoCommandHandler
    {
        CriarAmigoResponse Handle(CriarAmigoRequest request);
    }
}