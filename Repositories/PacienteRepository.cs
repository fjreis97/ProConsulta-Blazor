using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly ApplicationDbContext _context;
    public PacienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var paciente = await GetByIdAsync(id);
        if (paciente != null)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Paciente>> GetAllAsync()
    {
        return await _context.Pacientes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Paciente?> GetByIdAsync(int id)
    {
        return await _context.Pacientes
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Paciente paciente)
    {
         _context.Update(paciente);
        await _context.SaveChangesAsync();
    }
}
