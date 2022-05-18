using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api_inside.Migrations
{
    public partial class AddSurnameToOperatorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Operators",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Operators");
        }
    }
}
