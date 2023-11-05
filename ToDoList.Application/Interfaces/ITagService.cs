using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities.@base;

namespace ToDoList.Application.Interfaces
{
    public interface ITagService
    {
        Task<List<TagDTO>> GetAllAsync();
        Task<PagedSearchList<TagDTO>> FindAsync(string busca, int page, int pageSize);
        Task<TagDTO> GetByIdAsync(int id);
        Task<TagDTO> CreateAsync(TagDTO Tag);
        void Edit(TagDTO Tag);
        Task DeleteAsync(int id);
    }
}