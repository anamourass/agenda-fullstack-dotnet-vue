using Microsoft.EntityFrameworkCore;
using AgendaApiNova.Entities;

namespace AgendaApiNova.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contato> Contatos { get; set; } // Agora ele vai saber o que é Contato!
}