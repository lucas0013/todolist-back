using ToDoList.Domain.Interfaces;
using ToDoList.Domain.IRepositories;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private TarefaRepository _TarefaRepository;
        private TagRepository _TagRepository;
        public AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ITarefaRepository TarefaRepository
        {
            get
            {
                return _TarefaRepository = _TarefaRepository ?? new TarefaRepository(_context);
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                return _TagRepository = _TagRepository ?? new TagRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
