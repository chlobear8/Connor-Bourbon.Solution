using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnorBourbon.Migrations
{
    public partial class AddBourbonTagJoinEntitity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BourbonTag",
                columns: table => new
                {
                    BourbonTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BourbonId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BourbonTag", x => x.BourbonTagId);
                    table.ForeignKey(
                        name: "FK_BourbonTag_Bourbons_BourbonId",
                        column: x => x.BourbonId,
                        principalTable: "Bourbons",
                        principalColumn: "BourbonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BourbonTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BourbonTag_BourbonId",
                table: "BourbonTag",
                column: "BourbonId");

            migrationBuilder.CreateIndex(
                name: "IX_BourbonTag_TagId",
                table: "BourbonTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BourbonTag");
        }
    }
}
