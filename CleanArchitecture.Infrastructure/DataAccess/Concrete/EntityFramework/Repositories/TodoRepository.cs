using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.DataAccess.Concrete.EntityFramework.Contexts;

namespace CleanArchitecture.Infrastructure.DataAccess.Concrete.EntityFramework.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> Create(Todo todo)
        {
            await _context.AddAsync(todo);
            return todo;
        }
    }
}