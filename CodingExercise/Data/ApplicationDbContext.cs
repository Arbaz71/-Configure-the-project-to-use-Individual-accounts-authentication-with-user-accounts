using CodingExercise.Model;
using Microsoft.EntityFrameworkCore;

namespace CodingExercise.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Presentations> Presentation { get; set; }
        public DbSet<UserManagers> UserManager { get; set; }
    }
}
