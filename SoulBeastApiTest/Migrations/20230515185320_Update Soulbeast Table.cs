using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSoulbeastTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soulbeasts_Items_ItemId1",
                table: "Soulbeasts");

            migrationBuilder.DropIndex(
                name: "IX_Soulbeasts_ItemId1",
                table: "Soulbeasts");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Soulbeasts");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "Soulbeasts");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SoulbeastId",
                table: "Items",
                column: "SoulbeastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Soulbeasts_SoulbeastId",
                table: "Items",
                column: "SoulbeastId",
                principalTable: "Soulbeasts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Soulbeasts_SoulbeastId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_SoulbeastId",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Soulbeasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId1",
                table: "Soulbeasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soulbeasts_ItemId1",
                table: "Soulbeasts",
                column: "ItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Soulbeasts_Items_ItemId1",
                table: "Soulbeasts",
                column: "ItemId1",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
