using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mission6_Wong.Models
{
    // Design-time factory for EF Core migrations
    public class MovieContextFactory : IDesignTimeDbContextFactory<MovieContext>
    {
        public MovieContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieContext>();

            // Use your SQLite database file
            optionsBuilder.UseSqlite("Data Source=Movies.db");

            return new MovieContext(optionsBuilder.Options);
        }
    }
}