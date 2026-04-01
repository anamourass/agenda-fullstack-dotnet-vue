using AgendaApiNova.Entities;
using AgendaApiNova.Interfaces;
using AgendaApiNova.DTOs;
using AutoMapper;
using FluentValidation;

namespace AgendaApiNova.Services;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _repo;
    private readonly IMapper _mapper;
    private readonly IValidator<ContatoDTO> _validator;

    // O construtor recebe as 3 ferramentas: Banco, Tradutor e Segurança (Validador)
    public ContatoService(IContatoRepository repo, IMapper mapper, IValidator<ContatoDTO> validator)
    {
        _repo = repo;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<IEnumerable<Contato>> ListarTodos() 
        => await _repo.GetAllAsync();

    public async Task<Contato?> ObterPorId(int id) 
        => await _repo.GetByIdAsync(id);

    public async Task<Contato> Criar(ContatoDTO dto)
    {
        // 1. Validação: Pergunta ao FluentValidation se os dados estão corretos
        var resultado = await _validator.ValidateAsync(dto);
        
        if (!resultado.IsValid)
        {
            // Se houver erro, ele "grita" (lança uma exceção) com as mensagens de erro
            throw new ValidationException(resultado.Errors);
        }

        // 2. Mapeamento: Transforma o DTO em uma Entidade de banco
        var contato = _mapper.Map<Contato>(dto);
        
        // 3. Persistência: Salva no banco de dados
        await _repo.AddAsync(contato);
        
        return contato;
    }

    public async Task Atualizar(int id, ContatoDTO dto)
    {
        // Validação dos dados antes de atualizar
        var resultado = await _validator.ValidateAsync(dto);
        if (!resultado.IsValid) throw new ValidationException(resultado.Errors);

        var contatoExistente = await _repo.GetByIdAsync(id);
        
        if (contatoExistente != null)
        {
            // O AutoMapper copia os dados do DTO para o contato que já existe
            _mapper.Map(dto, contatoExistente); 
            await _repo.UpdateAsync(contatoExistente);
        }
    }

    public async Task Remover(int id)
    {
        await _repo.DeleteAsync(id);
    }
}