using System.Reflection;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.DataAccess.Concrete.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoProgress> TodoProgresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoProgressConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}