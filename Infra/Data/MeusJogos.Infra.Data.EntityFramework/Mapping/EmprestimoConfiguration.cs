using MeusJogos.Contexts.EmprestimoContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeusJogos.Infra.Data.Context.Mapping
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Jogo)
                .WithMany()
                .IsRequired()
                .HasForeignKey("Jogo_Id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Amigo)
                .WithMany()
                .IsRequired()
                .HasForeignKey("Amigo_Id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}