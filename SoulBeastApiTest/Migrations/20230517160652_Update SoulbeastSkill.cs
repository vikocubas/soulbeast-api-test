using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSoulbeastSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SoulbeastSkillId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SoulbeastSkillId",
                table: "Skills",
                column: "SoulbeastSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SoulbeastSkills_SoulbeastSkillId",
                table: "Skills",
                column: "SoulbeastSkillId",
                principalTable: "SoulbeastSkills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SoulbeastSkills_SoulbeastSkillId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SoulbeastSkillId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SoulbeastSkillId",
                table: "Skills");
        }
    }
}
