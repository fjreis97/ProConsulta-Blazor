using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Repositories;

public class MedicoRepository : IMedicorepository
{

    private readonly ApplicationDbContext _context;
    public MedicoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Medico Medico)
    {
        _context.Medicos.Add(Medico);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var Medico = await GetByIdAsync(id);
        if (Medico != null)
        {
            _context.Medicos.Remove(Medico);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Medico>> GetAllAsync()
    {
        return await _context.Medicos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
        return await _context.Medicos
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Medico Medico)
    {
        _context.Update(Medico);
        await _context.SaveChangesAsync();
    }
}
