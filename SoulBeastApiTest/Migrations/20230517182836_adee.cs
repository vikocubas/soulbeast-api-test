using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class adee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SoulbeastSkillId",
                table: "Soulbeasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoulbeastId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soulbeasts_SoulbeastSkillId",
                table: "Soulbeasts",
                column: "SoulbeastSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SoulbeastId",
                table: "Skills",
                column: "SoulbeastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Soulbeasts_SoulbeastId",
                table: "Skills",
                column: "SoulbeastId",
                principalTable: "Soulbeasts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soulbeasts_SoulbeastSkills_SoulbeastSkillId",
                table: "Soulbeasts",
                column: "SoulbeastSkillId",
                principalTable: "SoulbeastSkills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Soulbeasts_SoulbeastId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Soulbeasts_SoulbeastSkills_SoulbeastSkillId",
                table: "Soulbeasts");

            migrationBuilder.DropIndex(
                name: "IX_Soulbeasts_SoulbeastSkillId",
                table: "Soulbeasts");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SoulbeastId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SoulbeastSkillId",
                table: "Soulbeasts");

            migrationBuilder.DropColumn(
                name: "SoulbeastId",
                table: "Skills");
        }
    }
}
