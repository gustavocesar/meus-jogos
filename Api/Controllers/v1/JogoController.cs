using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusJogos.Context.Application.QueryResult;
using MeusJogos.Context.Application.QueryService.Contracts;
using MeusJogos.Contexts.JogoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.JogoContext.Application.Requests;
using MeusJogos.Contexts.JogoContext.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MeusJogos.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/jogos")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoCommandHandler _handler;
        private readonly IJogoQueryService _jogoQueryService;

        public JogoController(IJogoCommandHandler handler,
            IJogoQueryService jogoQueryService
            )
        {
            _handler = handler;
            _jogoQueryService = jogoQueryService;
        }

        [Route("")]
        [HttpGet]
        public ICollection<JogoQueryResult> Get()
        {
            return _jogoQueryService.GetJogos();
        }

        [Route("")]
        [HttpPost]
        public CriarJogoResponse CriarJogo([FromBody] CriarJogoRequest command)
        {
            return _handler.Handle(command);
        }
    }
}