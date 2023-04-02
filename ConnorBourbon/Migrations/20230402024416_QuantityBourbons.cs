﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnorBourbon.Migrations
{
    public partial class QuantityBourbons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Bourbons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Bourbons");
        }
    }
}
