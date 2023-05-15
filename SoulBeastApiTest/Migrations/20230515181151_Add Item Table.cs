using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class AddItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Soulbeasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rarity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soulbeasts_ItemId",
                table: "Soulbeasts",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soulbeasts_Items_ItemId",
                table: "Soulbeasts",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soulbeasts_Items_ItemId",
                table: "Soulbeasts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Soulbeasts_ItemId",
                table: "Soulbeasts");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Soulbeasts");
        }
    }
}
