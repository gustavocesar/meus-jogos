using System;
using MeusJogos.Contexts.JogoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.JogoContext.Application.Requests;
using MeusJogos.Contexts.JogoContext.Application.Responses;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using MeusJogos.Contexts.JogoContext.Domain.Enums;
using MeusJogos.Contexts.JogoContext.Domain.ValueObjects;
using MeusJogos.Infra.Data.Context;

namespace MeusJogos.Contexts.JogoContext.Application.Handlers
{
    //injetar o repository
    public class JogoCommandHandler : IJogoCommandHandler
    {
        private readonly DataContext _context;

        public JogoCommandHandler(DataContext context)
        {
            _context = context;
        }

        public CriarJogoResponse Handle(CriarJogoRequest request)
        {
            var titulo = new Titulo(request.Titulo);
            var jogo = new Jogo(titulo, request.Plataforma);

            if (jogo.Invalid)
            {
                var error = jogo.Notifications;
            }

            _context.Jogos.Add(jogo);
            _context.SaveChanges();

            return new CriarJogoResponse
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo.Nome,
                Plataforma = jogo.Plataforma
            };
        }
    }
}