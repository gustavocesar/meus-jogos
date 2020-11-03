using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusJogos.Infra.CrossCutting.Auth.Models;
using MeusJogos.Infra.CrossCutting.Auth.Repositories;
using MeusJogos.Infra.CrossCutting.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeusJogos.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
