using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Todo : IEntity
    {
        public Todo()
        {
            TodoProgresses = new HashSet<TodoProgress>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<TodoProgress> TodoProgresses { get; set; }
        public Guid Id { get; set; }
    }
}