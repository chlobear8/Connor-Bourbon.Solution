using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnorBourbon.Migrations
{
    public partial class AddUserToBourbon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bourbons",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bourbons_UserId",
                table: "Bourbons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bourbons_AspNetUsers_UserId",
                table: "Bourbons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bourbons_AspNetUsers_UserId",
                table: "Bourbons");

            migrationBuilder.DropIndex(
                name: "IX_Bourbons_UserId",
                table: "Bourbons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bourbons");
        }
    }
}
