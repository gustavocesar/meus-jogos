using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeusJogos.Infra.Data.Context.Mapping
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(x => x.Id);

            // builder.OwnsOne(x => x.Amigo)
            //     .Property(x => x.Id)
            //     // .HasColumnName("AMIGO_ID")
            //     .IsRequired();

            // builder.OwnsOne(x => x.Jogo)
            //     .Property(x => x.Id)
            //     // .HasColumnName("JOGO_ID")
            //     .IsRequired();
        }
    }
}