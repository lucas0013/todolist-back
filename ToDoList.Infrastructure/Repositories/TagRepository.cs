using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Entities.@base;
using ToDoList.Domain.IRepositories;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Repositories.@base;

namespace ToDoList.Infrastructure.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public readonly AppDbContext _context;
        public TagRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedSearchList<Tag>> FindAsync(string busca, int page, int pageSize)
        {
            var query = _context.Tags
                        .Where(t => t.Nome.ToUpper().Trim().Contains(busca.ToUpper().Trim()));

            var list = await query.Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return new PagedSearchList<Tag>
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalResults = await query.CountAsync(),
                ItemsList = list
            };

        }
    }
}