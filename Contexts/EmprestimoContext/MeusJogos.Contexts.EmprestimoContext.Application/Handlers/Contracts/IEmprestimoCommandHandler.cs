using MeusJogos.Contexts.EmprestimoContext.Application.Requests;
using MeusJogos.Contexts.EmprestimoContext.Application.Response;

namespace MeusJogos.Contexts.EmprestimoContext.Application.Handlers.Contracts
{
    public interface IEmprestimoCommandHandler
    {
        CriarEmprestimoResponse Handle(CriarEmprestimoRequest request);
    }
}