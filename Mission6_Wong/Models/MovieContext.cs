using Microsoft.EntityFrameworkCore;

namespace Mission07_Wong.Models
{
    public class MovieContext : DbContext 
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
