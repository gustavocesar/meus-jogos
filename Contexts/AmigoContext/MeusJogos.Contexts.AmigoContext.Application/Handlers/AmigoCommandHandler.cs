using System;
using MeusJogos.Contexts.AmigoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.AmigoContext.Application.Requests;
using MeusJogos.Contexts.AmigoContext.Application.Responses;
using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using MeusJogos.Contexts.AmigoContext.Domain.ValueObjects;
using MeusJogos.Infra.Data.Context;

namespace MeusJogos.Contexts.AmigoContext.Application.Handlers
{
    //injetar o repository
    public class AmigoCommandHandler : IAmigoCommandHandler
    {
        private readonly DataContext _context;

        public AmigoCommandHandler(DataContext context)
        {
            _context = context;
        }

        public CriarAmigoResponse Handle(CriarAmigoRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.SobreNome);
            var celular = new Celular(request.Ddd, request.Numero);
            var amigo = new Amigo(nome, celular);

            _context.Amigos.Add(amigo);
            _context.SaveChanges();

            return new CriarAmigoResponse
            {
                Id = amigo.Id,
                Nome = amigo.Nome.ToString(),
                Celular = amigo.Celular.ToString()
            };
        }
    }
}