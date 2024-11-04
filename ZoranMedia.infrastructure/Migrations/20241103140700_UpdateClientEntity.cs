using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoranMedia.Infrastructure.Migrations
{
    public partial class UpdateClientEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Clients");
        }
    }
}
