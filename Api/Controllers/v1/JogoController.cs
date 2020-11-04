using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusJogos.Contexts.JogoContext.Application.QueryResult;
using MeusJogos.Contexts.JogoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.JogoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.JogoContext.Application.Requests;
using MeusJogos.Contexts.JogoContext.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MeusJogos.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/jogos")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoCommandHandler _handler;
        private readonly IJogoQueryService _jogoQueryService;

        public JogoController(IJogoCommandHandler handler, IJogoQueryService jogoQueryService)
        {
            _handler = handler;
            _jogoQueryService = jogoQueryService;
        }

        [Route("")]
        [HttpGet]
        [Authorize]
        public ICollection<JogoQueryResult> Get()
        {
            return _jogoQueryService.GetJogos();
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize]
        public JogoQueryResult Get(Guid id)
        {
            return _jogoQueryService.GetJogo(id);
        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public CriarJogoResponse CriarJogo([FromBody] CriarJogoRequest command)
        {
            return _handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public AlterarJogoResponse AlterarJogo([FromBody] AlterarJogoRequest command)
        {
            return _handler.Handle(command);
        }
    }
}