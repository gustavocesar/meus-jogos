using MeusJogos.Contexts.AmigoContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeusJogos.Infra.Data.Context.Mapping
{
    public class AmigoConfiguration : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Amigo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Nome)
                .Property(x => x.PrimeiroNome)
                .HasColumnName("PrimeiroNome")
                .IsRequired();

            builder.OwnsOne(x => x.Nome)
                .Property(x => x.SobreNome)
                .HasColumnName("SobreNome")
                .IsRequired();

            builder.OwnsOne(x => x.Celular)
                .Property(x => x.Ddd)
                .HasColumnName("Ddd")
                .IsRequired();

            builder.OwnsOne(x => x.Celular)
                .Property(x => x.Numero)
                .HasColumnName("Numero")
                .IsRequired();
        }
    }
}