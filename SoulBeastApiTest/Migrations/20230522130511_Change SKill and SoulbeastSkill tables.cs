using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSKillandSoulbeastSkilltables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "SoulbeastSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SoulbeastSkills_SkillId",
                table: "SoulbeastSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoulbeastSkills_Skills_SkillId",
                table: "SoulbeastSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoulbeastSkills_Skills_SkillId",
                table: "SoulbeastSkills");

            migrationBuilder.DropIndex(
                name: "IX_SoulbeastSkills_SkillId",
                table: "SoulbeastSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "SoulbeastSkills");

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
    }
}
