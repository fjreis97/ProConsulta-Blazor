using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;
using ProConsulta.Models.Dtos.ViewModel;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Repositories;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly ApplicationDbContext _context;
    public AgendamentoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Agendamento Agendamento)
    {
        _context.Agendamentos.Add(Agendamento);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteByIdAsync(int id)
    {
        var Agendamento = await GetByIdAsync(id);
        if (Agendamento != null)
        {
            _context.Agendamentos.Remove(Agendamento);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Agendamento>> GetAllAsync()
    {
        return await _context.Agendamentos
            .AsNoTracking()
            .Include(a => a.Paciente)
            .Include(a => a.Medico)
            .ToListAsync();
    }
    public async Task<Agendamento?> GetByIdAsync(int id)
    {
        return await _context.Agendamentos
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);
    }
    public async Task UpdateAsync(Agendamento Agendamento)
    {
        _context.Update(Agendamento);
        await _context.SaveChangesAsync();
    }


    //Reports

    public async Task<List<AgendamentosAnuais>> GetReportAsync()
    {
        var result = _context.Database.
            SqlQuery<AgendamentosAnuais>($"SELECT MONTH(DataConsulta) AS Mes, COUNT(*) AS QuantidadeAgendamentos FROM dbo.Agendamentos WHERE  YEAR(DataConsulta) = '2025' GROUP BY MONTH(DataConsulta)");
        return await Task.FromResult(result.ToList());
    }
}
