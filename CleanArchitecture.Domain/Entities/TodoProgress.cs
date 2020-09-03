using System;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Common.Enums;

namespace CleanArchitecture.Domain.Entities
{
    public class TodoProgress : IEntityHistory
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Todo Todo { get; set; }

        public Guid TodoId { get; set; }

        public Status Status { get; set; }
    }
}