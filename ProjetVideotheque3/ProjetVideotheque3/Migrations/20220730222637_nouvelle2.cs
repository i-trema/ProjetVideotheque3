using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetVideotheque3.Migrations
{
    public partial class nouvelle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IMDbNote",
                table: "Films",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMDbNote",
                table: "Films");
        }
    }
}
