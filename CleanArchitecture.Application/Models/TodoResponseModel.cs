using System;

namespace CleanArchitecture.Application.Models
{
    public class TodoResponseModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}