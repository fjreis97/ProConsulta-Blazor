using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("Medicos");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Documento)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(m => m.CRM)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(m => m.DataCadastro)
            .IsRequired();

        builder.Property(m => m.Celular)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(x => x.EspecialidadeId)
            .IsRequired();

        builder.HasIndex(m => m.CRM)
            .IsUnique();

        builder.HasIndex(m => m.Documento)
            .IsUnique();

        builder.HasOne(m => m.Especialidade)
            .WithMany(e => e.Medicos)
            .HasForeignKey(m => m.EspecialidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.Agendamentos)
            .WithOne(a => a.Medico)
            .HasForeignKey(a => a.MedicoId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
