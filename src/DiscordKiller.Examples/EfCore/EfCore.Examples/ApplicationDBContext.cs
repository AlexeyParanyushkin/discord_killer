using Microsoft.EntityFrameworkCore;

namespace EfCore.Examples;

public class ApplicationDBContext : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public ApplicationDBContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source=app.db");
    }
}