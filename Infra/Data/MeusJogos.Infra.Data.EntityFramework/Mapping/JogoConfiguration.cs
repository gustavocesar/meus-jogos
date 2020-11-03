using MeusJogos.Contexts.JogoContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeusJogos.Infra.Data.Context.Mapping
{
    public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Titulo)
                .Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired();
        }
    }
}