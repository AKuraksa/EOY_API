using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOY_API.Migrations
{
    /// <inheritdoc />
    public partial class _6e8bc914cacd416284bc69f46a23ea9f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoryErrors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeError = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryErrors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthentificatorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoggedWorkplace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workplaces",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkplaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLogged = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetHELP = table.Column<bool>(type: "bit", nullable: false),
                    GetINFO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplaces", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryErrors");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Workplaces");
        }
    }
}
