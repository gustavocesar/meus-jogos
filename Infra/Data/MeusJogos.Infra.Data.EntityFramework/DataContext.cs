using Microsoft.EntityFrameworkCore;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using Flunt.Notifications;
using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context.Mapping;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;

namespace MeusJogos.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //connection string
        }

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new JogoConfiguration());
            modelBuilder.ApplyConfiguration(new AmigoConfiguration());
            modelBuilder.ApplyConfiguration(new EmprestimoConfiguration());
        }
    }
}