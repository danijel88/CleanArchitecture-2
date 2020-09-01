using System;
using CleanArchitecture.Application.CrossCuttingConcerns.Mapping;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Models
{
    public class TodoResponseModel : IMapFrom<Todo>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}