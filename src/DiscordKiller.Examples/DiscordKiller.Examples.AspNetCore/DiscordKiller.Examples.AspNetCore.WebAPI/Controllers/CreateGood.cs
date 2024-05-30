namespace DiscordKiller.Examples.AspNetCore.WebAPI.Controllers;

public class CreateGood
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public decimal Price { get; set; }
    public int Stock { get; set; }
}