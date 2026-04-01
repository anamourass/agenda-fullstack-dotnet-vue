using AgendaApiNova.Data;
using AgendaApiNova.Entities;
using AgendaApiNova.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaApiNova.Repositories;

public class ContatoRepository : IContatoRepository 
{
    private readonly AppDbContext _context;
    
    public ContatoRepository(AppDbContext context) 
    {
        _context = context;
    }

    public async Task<IEnumerable<Contato>> GetAllAsync() 
        => await _context.Contatos.ToListAsync();

    // Aqui usamos a interrogação (?) para dizer que o contato pode ser nulo (não encontrado)
    public async Task<Contato?> GetByIdAsync(int id) 
        => await _context.Contatos.FindAsync(id);

    public async Task AddAsync(Contato contato) 
    { 
        await _context.Contatos.AddAsync(contato); 
        await _context.SaveChangesAsync(); 
    }

    public async Task UpdateAsync(Contato contato) 
    {
        _context.Contatos.Update(contato);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) 
    {
        var contato = await GetByIdAsync(id);
        if (contato != null) 
        {
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }
    }
}