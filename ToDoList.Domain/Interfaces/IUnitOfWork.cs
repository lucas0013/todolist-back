using ToDoList.Domain.IRepositories;

namespace ToDoList.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ITarefaRepository TarefaRepository { get; }
        ITagRepository TagRepository { get; }
        Task Commit();
    }
}
