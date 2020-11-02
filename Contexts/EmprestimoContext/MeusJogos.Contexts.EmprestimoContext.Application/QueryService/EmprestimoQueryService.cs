using MeusJogos.Contexts.EmprestimoContext.Application.QueryResult;
using MeusJogos.Contexts.EmprestimoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MeusJogos.Contexts.EmprestimoContext.Application.QueryService
{
    public class EmprestimoQueryService : IEmprestimoQueryService
    {
        private readonly DataContext _context;

        public EmprestimoQueryService(DataContext context)
        {
            _context = context;
        }

        public ICollection<EmprestimoQueryResult> GetEmprestimos()
        {
            var emprestimos = _context.Emprestimos
                .Include(j => j.Jogo)
                .Include(a => a.Amigo);

            var list = new List<EmprestimoQueryResult>();

            foreach (var emprestimo in emprestimos)
            {
                list.Add(new EmprestimoQueryResult
                {
                    Id = emprestimo.Id,
                    Jogo = emprestimo.Jogo.ToString(),
                    Amigo = emprestimo.Amigo.ToString(),
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao
                });
            }

            return list;
        }
    }
}

