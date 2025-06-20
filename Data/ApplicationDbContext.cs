using Microsoft.EntityFrameworkCore;
using MyFirstWebApi.Data.Models;

namespace MyFirstWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
