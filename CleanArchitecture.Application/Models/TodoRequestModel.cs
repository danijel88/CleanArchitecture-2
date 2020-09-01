using CleanArchitecture.Application.CrossCuttingConcerns.Mapping;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Models
{
    public class TodoCreateRequestModel: IMapTo<Todo>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}