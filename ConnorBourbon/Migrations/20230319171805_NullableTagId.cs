using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnorBourbon.Migrations
{
    public partial class NullableTagId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BourbonTag_Tags_TagId",
                table: "BourbonTag");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "BourbonTag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BourbonTag_Tags_TagId",
                table: "BourbonTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BourbonTag_Tags_TagId",
                table: "BourbonTag");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "BourbonTag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BourbonTag_Tags_TagId",
                table: "BourbonTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
