using AutoMapper;
using AgendaApiNova.Entities;
using AgendaApiNova.DTOs;

namespace AgendaApiNova.Mappings;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<Contato, ContatoDTO>().ReverseMap();
    }
}