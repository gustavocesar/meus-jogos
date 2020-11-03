using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusJogos.Contexts.JogoContext.Application.QueryResult;
using MeusJogos.Contexts.JogoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.AmigoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.AmigoContext.Application.Requests;
using MeusJogos.Contexts.AmigoContext.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using MeusJogos.Contexts.AmigoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.AmigoContext.Application.QueryResult;
using Microsoft.AspNetCore.Authorization;

namespace MeusJogos.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/amigos")]
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoCommandHandler _handler;
        private readonly IAmigoQueryService _amigoQueryService;

        public AmigoController(IAmigoCommandHandler handler,
            IAmigoQueryService amigoQueryService
        )
        {
            _handler = handler;
            _amigoQueryService = amigoQueryService;
        }

        [Route("")]
        [HttpGet]
        [Authorize]
        public ICollection<AmigoQueryResult> Get()
        {
            return _amigoQueryService.GetAmigos();
        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public CriarAmigoResponse CriarAmigo([FromBody] CriarAmigoRequest command)
        {
            return _handler.Handle(command);
        }
    }
}