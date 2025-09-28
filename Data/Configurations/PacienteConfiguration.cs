using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Documento)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Celular)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(p => p.DataNascimento)
            .IsRequired();

        builder.HasMany(p => p.Agendamentos)
            .WithOne(a => a.Paciente)
            .HasForeignKey(a => a.PacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Documento)
            .IsUnique();
    }
}
