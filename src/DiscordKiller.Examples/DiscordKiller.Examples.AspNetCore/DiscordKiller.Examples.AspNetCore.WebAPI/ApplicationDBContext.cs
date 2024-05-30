using DiscordKiller.Examples.AspNetCore.WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace DiscordKiller.Examples.AspNetCore.WebAPI;

public class ApplicationDBContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Good> Goods { get; set; }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
        
    }
}