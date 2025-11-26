using Microsoft.EntityFrameworkCore;

namespace API.J.Movies.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Models.Category> categories { get; set; }
        public DbSet<Models.Movie> movies { get; set; }
    }
}
