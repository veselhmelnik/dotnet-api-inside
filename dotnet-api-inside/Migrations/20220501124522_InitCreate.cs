using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api_inside.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Build = table.Column<bool>(type: "bit", nullable: true),
                    Check = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
