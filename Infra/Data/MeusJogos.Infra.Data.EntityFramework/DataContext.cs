using Microsoft.EntityFrameworkCore;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using Flunt.Notifications;
using MeusJogos.Contexts.JogoContext.Domain.ValueObjects;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Titulo>();
        }
    }
}