using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api_inside.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QAId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Ready",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OperatorId",
                table: "Projects",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_QAId",
                table: "Projects",
                column: "QAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Operators_OperatorId",
                table: "Projects",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Operators_QAId",
                table: "Projects",
                column: "QAId",
                principalTable: "Operators",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Operators_OperatorId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Operators_QAId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_Projects_OperatorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_QAId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "QAId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Ready",
                table: "Projects");
        }
    }
}
