using AgendaApiNova.Entities; 
using AgendaApiNova.DTOs;
using AgendaApiNova.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AgendaApiNova.Services;

namespace AgendaApiNova.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContatosController : ControllerBase
{
    private readonly ContatoService _service;
    public ContatosController(ContatoService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Contato>>> Get() => Ok(await _service.ListarTodos());

    [HttpGet("{id}")]
    public async Task<ActionResult<Contato>> Get(int id)
    {
        var contato = await _service.ObterPorId(id);
        return contato is null ? NotFound() : Ok(contato);
    }

    [HttpPost]
    public async Task<ActionResult<Contato>> Post([FromBody] ContatoDTO dto)
    {
        var contato = await _service.Criar(dto);
        return CreatedAtAction(nameof(Get), new { id = contato.Id }, contato);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ContatoDTO dto)
    {
        await _service.Atualizar(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Remover(id);
        return NoContent();
    }
}