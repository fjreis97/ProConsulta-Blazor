using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;
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
}
