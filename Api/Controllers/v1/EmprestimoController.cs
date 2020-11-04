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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public ICollection<EmprestimoQueryResult> Get()
        {
            return _emprestimoQueryService.GetEmprestimos();
        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public EmprestarJogoResponse EmprestarJogo([FromBody] EmprestarJogoRequest command)
        {
            return _handler.Handle(command);
        }

        [Route("devolver")]
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public DevolverJogoResponse DevolverJogo([FromBody] DevolverJogoRequest command)
        {
            return _handler.Handle(command);
        }

        [Route("get-jogos-emprestados")]
        [HttpGet]
        [Authorize]
        public ICollection<JogosEmprestadosQueryResult> GetJogosEmprestados()
        {
            return _emprestimoQueryService.GetJogosEmprestados();
        }

        [Route("get-jogos-disponiveis")]
        [HttpGet]
        [Authorize]
        public ICollection<JogosDisponiveisQueryResult> GetJogosDisponiveis()
        {
            return _emprestimoQueryService.GetJogosDisponiveis();
        }
    }
}