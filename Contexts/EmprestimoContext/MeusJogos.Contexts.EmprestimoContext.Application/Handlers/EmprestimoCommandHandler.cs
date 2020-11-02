using System;
using System.Linq;
using MeusJogos.Contexts.EmprestimoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Application.Requests;
using MeusJogos.Contexts.EmprestimoContext.Application.Response;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context;

namespace MeusJogos.Contexts.EmprestimoContext.Application.Handlers
{
    //injetar o repository
    public class EmprestimoCommandHandler : IEmprestimoCommandHandler
    {
        private readonly DataContext _context;

        public EmprestimoCommandHandler(DataContext context)
        {
            _context = context;
        }

        public CriarEmprestimoResponse Handle(CriarEmprestimoRequest request)
        {
            var amigo = _context.Amigos
                .Where(a => a.Id == request.AmigoId)
                .FirstOrDefault();

            var jogo = _context.Jogos
                .Where(j => j.Id == request.JogoId)
                .FirstOrDefault();

            var emprestimo = new Emprestimo(amigo, jogo);
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return new CriarEmprestimoResponse
            {
                Id = emprestimo.Id,
                Amigo = amigo,
                Jogo = jogo
            };
        }
    }
}