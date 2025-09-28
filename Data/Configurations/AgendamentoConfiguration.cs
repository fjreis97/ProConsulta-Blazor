using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
{
    public void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        
        builder.ToTable("Agendamentos");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Observacao)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(a => a.PacienteId)
            .IsRequired();

        builder.Property(a => a.MedicoId)
            .IsRequired();

        builder.Property(a => a.HoraConsulta)
            .IsRequired();

        builder.Property(a => a.DataConsulta)
            .IsRequired();

        builder.HasOne(a => a.Paciente)
            .WithMany(p => p.Agendamentos)
            .HasForeignKey(a => a.PacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Medico)
            .WithMany(m => m.Agendamentos)
            .HasForeignKey(a => a.MedicoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
