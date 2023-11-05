using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Entities.@base;

namespace Catalogo.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Tarefa, TarefaDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<PagedSearchList<Tarefa>, PagedSearchList<TarefaDTO>>().ReverseMap();
            CreateMap<PagedSearchList<Tag>, PagedSearchList<TagDTO>>().ReverseMap();
        }
    }
}
