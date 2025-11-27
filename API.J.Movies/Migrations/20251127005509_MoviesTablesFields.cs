using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.J.Movies.Migrations
{
    /// <inheritdoc />
    public partial class MoviesTablesFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Clasification",
                table: "movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clasification",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "movies");
        }
    }
}
