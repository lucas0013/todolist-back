using ToDoList.Domain.Entities;
using ToDoList.Domain.Entities.@base;
using ToDoList.Domain.IRepositories.@base;

namespace ToDoList.Domain.IRepositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<PagedSearchList<Tag>> FindAsync(string busca, int page, int pageSize);
    }
}