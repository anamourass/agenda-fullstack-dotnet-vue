using AgendaApiNova.Entities;
using AgendaApiNova.DTOs;

namespace AgendaApiNova.Interfaces;

public interface IContatoService
{
    Task<IEnumerable<Contato>> ListarTodos(); // Mudamos para IEnumerable para facilitar
    Task<Contato?> ObterPorId(int id);
    Task<Contato> Criar(ContatoDTO dto);
    
}