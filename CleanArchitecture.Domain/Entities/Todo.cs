using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Todo : IEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}