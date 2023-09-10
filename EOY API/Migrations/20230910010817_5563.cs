using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOY_API.Migrations
{
    /// <inheritdoc />
    public partial class _5563 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserLogged",
                table: "Workplaces",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLogged",
                table: "Workplaces");
        }
    }
}
