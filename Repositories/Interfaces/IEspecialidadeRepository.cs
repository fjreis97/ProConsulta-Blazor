using ProConsulta.Models;

namespace ProConsulta.Repositories.Interfaces;

public interface IEspecialidadeRepository
{
    Task AddAsync(Especialidade especialidade);
    Task UpdateAsync(Especialidade especialidade);
    Task<List<Especialidade>> GetAllAsync();
    Task DeleteByIdAsync(int id);
    Task<Especialidade?> GetByIdAsync(int id);
}
