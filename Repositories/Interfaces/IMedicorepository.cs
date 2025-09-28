using ProConsulta.Models;

namespace ProConsulta.Repositories.Interfaces;

public interface IMedicorepository
{
    Task AddAsync(Medico Medico);
    Task UpdateAsync(Medico Medico);
    Task<List<Medico>> GetAllAsync();
    Task DeleteByIdAsync(int id);
    Task<Medico?> GetByIdAsync(int id);
}
