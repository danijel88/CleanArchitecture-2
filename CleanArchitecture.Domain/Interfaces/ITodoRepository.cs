using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> Create(Todo todo);
    }
}