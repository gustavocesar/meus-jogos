using Microsoft.EntityFrameworkCore;
using MeusJogos.Contexts.JogoContext.Domain.Entities;
using Flunt.Notifications;
using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using MeusJogos.Infra.Data.Context.Mapping;
using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MeusJogos.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var configuration = new ConfigurationBuilder()
                //     .SetBasePath(Directory.GetCurrentDirectory() + "/../../MyApiFolder")
                //     .AddJsonFile("appsettings.json", false, true)
                //     .Build();
                //var connectionString = configuration.GetConnectionString("DefaultConnection");

                //optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.UseSqlServer("Data Source=sql-server,1433;Initial Catalog=MEUS_JOGOS;User ID=sa;Password=Meus-jogos@123");
            }
        }
    }
}