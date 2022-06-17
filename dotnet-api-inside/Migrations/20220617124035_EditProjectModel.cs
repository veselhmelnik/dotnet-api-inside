using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api_inside.Migrations
{
    public partial class EditProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Operators_OperatorId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Operators_QAId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_OperatorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_QAId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "QAId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorTime",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Qa",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QaTime",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OperatorTime",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Qa",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "QaTime",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

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
    }
}
