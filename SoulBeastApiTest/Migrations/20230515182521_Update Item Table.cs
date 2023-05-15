using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soulbeasts_Items_ItemId",
                table: "Soulbeasts");

            migrationBuilder.DropIndex(
                name: "IX_Soulbeasts_ItemId",
                table: "Soulbeasts");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId1",
                table: "Soulbeasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoulbeastId",
                table: "Items",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soulbeasts_Items_ItemId1",
                table: "Soulbeasts");

            migrationBuilder.DropIndex(
                name: "IX_Soulbeasts_ItemId1",
                table: "Soulbeasts");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "Soulbeasts");

            migrationBuilder.DropColumn(
                name: "SoulbeastId",
                table: "Items");

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
    }
}
