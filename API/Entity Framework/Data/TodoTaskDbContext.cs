using Microsoft.EntityFrameworkCore;
using Entity_Framework.Models;

namespace Entity_Framework.Data
{
    public class TodoTaskDbContext : DbContext
    {
        public DbSet<TodoTask> Tasks => Set<TodoTask>();
        public DbSet<User> Users => Set<User>();

        public TodoTaskDbContext(DbContextOptions<TodoTaskDbContext> options)
            : base(options)
        {
            // "base(options)" sikrer, at constructor
            // på DbContext super-klassen bliver kaldt.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
