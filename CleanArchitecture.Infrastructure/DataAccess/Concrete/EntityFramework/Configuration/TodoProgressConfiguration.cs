using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.DataAccess.Concrete.EntityFramework.Configuration
{
    public class TodoProgressConfiguration : IEntityTypeConfiguration<TodoProgress>
    {
        public void Configure(EntityTypeBuilder<TodoProgress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

        }
    }
}