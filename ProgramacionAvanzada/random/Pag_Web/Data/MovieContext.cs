using Microsoft.EntityFrameworkCore;
using Movie.Model;

namespace Movie.Data;
public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {

    }

    public DbSet<Movies> Movies => Set <Movies>();
}