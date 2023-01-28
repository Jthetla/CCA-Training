using Microsoft.EntityFrameworkCore;

namespace TodoApp.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
