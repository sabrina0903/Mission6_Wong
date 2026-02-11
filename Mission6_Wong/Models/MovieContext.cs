using Microsoft.EntityFrameworkCore;

namespace Mission6_Wong.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
    }
}