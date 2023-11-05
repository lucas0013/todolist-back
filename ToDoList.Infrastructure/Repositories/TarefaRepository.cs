using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Entities.@base;
using ToDoList.Domain.IRepositories;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Repositories.@base;

namespace ToDoList.Infrastructure.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedSearchList<Tarefa>> FindAsync(string busca, int page, int pageSize) {

            var query = _context.Tarefas.Where(t => t.Titulo.ToUpper().Trim().Contains(busca.ToUpper().Trim()));

            var list = await query.Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return new PagedSearchList<Tarefa> {
                CurrentPage = page,
                PageSize = pageSize,
                TotalResults = await query.CountAsync(),
                ItemsList = list
            };
        }
    }
}
