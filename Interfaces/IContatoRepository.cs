using AgendaApiNova.Entities;

namespace AgendaApiNova.Interfaces;

public interface IContatoRepository
{
    Task<IEnumerable<Contato>> GetAllAsync();
    Task<Contato> GetByIdAsync(int id);
    Task AddAsync(Contato contato);
    Task UpdateAsync(Contato contato);
    Task DeleteAsync(int id);
}