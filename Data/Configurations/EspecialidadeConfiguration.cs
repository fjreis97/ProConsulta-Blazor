using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        
        builder.ToTable("Especialidades");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Descricao)
            .IsRequired(false)
            .HasMaxLength(255);

        builder.HasMany(e => e.Medicos)
            .WithOne(m => m.Especialidade)
            .HasForeignKey(m => m.EspecialidadeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
