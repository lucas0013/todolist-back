using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities.@base;

namespace ToDoList.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<List<TarefaDTO>> GetAllAsync();
        Task<PagedSearchList<TarefaDTO>> FindAsync(string busca, int page, int pageSize);
        Task<TarefaDTO> GetByIdAsync(int id);
        Task<TarefaDTO> CreateAsync(TarefaDTO tarefa);
        void Edit(TarefaDTO tarefa);
        Task DeleteAsync(int id);
    }
}
