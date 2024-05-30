using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscordKiller.Examples.AspNetCore.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCityCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "WeatherForecasts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "WeatherForecasts");
        }
    }
}
