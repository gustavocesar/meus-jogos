using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeusJogos.Contexts.EmprestimoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Application.QueryResult;
using MeusJogos.Contexts.EmprestimoContext.Application.Response;
using MeusJogos.Contexts.EmprestimoContext.Application.Requests;

namespace MeusJogos.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/emprestimos")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoCommandHandler _handler;
        private readonly IEmprestimoQueryService _emprestimoQueryService;

        public EmprestimoController(IEmprestimoCommandHandler handler,
            IEmprestimoQueryService emprestimoQueryService
        )
        {
            _handler = handler;
            _emprestimoQueryService = emprestimoQueryService;
        }

        [Route("")]
        [HttpGet]
        public ICollection<EmprestimoQueryResult> Get()
        {
            return _emprestimoQueryService.GetEmprestimos();
        }

        [Route("")]
        [HttpPost]
        public CriarEmprestimoResponse CriarEmprestimo([FromBody] CriarEmprestimoRequest command)
        {
            return _handler.Handle(command);
        }
    }
}