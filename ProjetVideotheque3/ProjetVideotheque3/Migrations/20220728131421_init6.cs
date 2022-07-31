using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetVideotheque3.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Affiche",
                table: "Films",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Affiche",
                table: "Films");
        }
    }
}
