using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerDatabaseTutorial.Migrations
{
    /// <inheritdoc />
    public partial class IncludeEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VolunteerEmail",
                table: "Volunteers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolunteerEmail",
                table: "Volunteers");
        }
    }
}
