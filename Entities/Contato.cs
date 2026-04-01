namespace AgendaApiNova.Entities;

public class Contato
{
    public int Id { get; set; } // O "RG" que estava faltando!
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}