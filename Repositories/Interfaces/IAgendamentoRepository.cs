using ProConsulta.Models;

namespace ProConsulta.Repositories.Interfaces;

public interface IAgendamentoRepository
{
    Task AddAsync(Agendamento agendamento);
    Task UpdateAsync(Agendamento agendamento);
    Task<List<Agendamento>> GetAllAsync();
    Task DeleteByIdAsync(int id);
    Task<Agendamento?> GetByIdAsync(int id);
}
