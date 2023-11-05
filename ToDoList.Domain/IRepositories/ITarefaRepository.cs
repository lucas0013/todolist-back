using ToDoList.Domain.Entities;
using ToDoList.Domain.Entities.@base;
using ToDoList.Domain.IRepositories.@base;

namespace ToDoList.Domain.IRepositories
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<PagedSearchList<Tarefa>> FindAsync(string busca, int page, int pageSize);
    }
}
