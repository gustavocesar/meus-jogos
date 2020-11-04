using System;
using System.Linq;
using MeusJogos.Contexts.EmprestimoContext.Application.Handlers.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Application.Requests;
using MeusJogos.Contexts.EmprestimoContext.Application.Response;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context;

namespace MeusJogos.Contexts.EmprestimoContext.Application.Handlers
{
    public class EmprestimoCommandHandler : IEmprestimoCommandHandler
    {
        private readonly DataContext _context;

        public EmprestimoCommandHandler(DataContext context)
        {
            _context = context;
        }

        public EmprestarJogoResponse Handle(EmprestarJogoRequest request)
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

            return new EmprestarJogoResponse
            {
                Id = emprestimo.Id,
                Amigo = amigo,
                Jogo = jogo
            };
        }

        public DevolverJogoResponse Handle(DevolverJogoRequest request)
        {
            var emprestimo = _context.Emprestimos
                .Where(x => x.Id == request.EmprestimoId)
                .FirstOrDefault();

            emprestimo.Devolver();
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();

            return new DevolverJogoResponse
            {
            };
        }
    }
}