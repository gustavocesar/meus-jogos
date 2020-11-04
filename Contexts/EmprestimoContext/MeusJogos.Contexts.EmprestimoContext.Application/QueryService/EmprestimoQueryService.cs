using MeusJogos.Contexts.EmprestimoContext.Application.QueryResult;
using MeusJogos.Contexts.EmprestimoContext.Application.QueryService.Contracts;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .OrderBy(x => x.Jogo.Titulo.Nome)
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

        public ICollection<JogosEmprestadosQueryResult> GetJogosEmprestados()
        {
            return (
                from j in _context.Jogos
                join e in _context.Emprestimos on j.Id equals e.Jogo.Id
                join a in _context.Amigos on e.Amigo.Id equals a.Id
                orderby j.Titulo.Nome
                select new JogosEmprestadosQueryResult
                {
                    Id = e.Id,
                    Amigo = a.ToString(),
                    Jogo = j.ToString(),
                    DataEmprestimo = e.DataEmprestimo
                })
                .ToList();
        }

        public ICollection<JogosDisponiveisQueryResult> GetJogosDisponiveis()
        {
            return (
                from j in _context.Jogos
                join e in _context.Emprestimos on j.Id equals e.Jogo.Id into emp
                from leftEmprestimos in emp.DefaultIfEmpty()
                where leftEmprestimos.Id == null
                orderby j.Titulo.Nome
                select new JogosDisponiveisQueryResult
                {
                    Id = j.Id,
                    Jogo = j.ToString()
                })
                .ToList();
        }
    }
}

