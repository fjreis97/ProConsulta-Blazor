using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Repositories;

public class EspecialidadeRepository : IEspecialidadeRepository
{
    private readonly ApplicationDbContext _context;
    public EspecialidadeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Especialidade especialidade)
    {
        _context.Especialidades.Add(especialidade);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteByIdAsync(int id)
    {
        var especialidade = await GetByIdAsync(id);
        if (especialidade != null)
        {
            _context.Especialidades.Remove(especialidade);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Especialidade>> GetAllAsync()
    {
        return await _context.Especialidades
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Especialidade?> GetByIdAsync(int id)
    {
        return await _context.Especialidades
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);
    }
    public async Task UpdateAsync(Especialidade especialidade)
    {
        _context.Update(especialidade);
        await _context.SaveChangesAsync();
    }
}
