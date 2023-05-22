using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class fsaeofnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soulbeasts_SoulbeastSkills_SoulbeastSkillId",
                table: "Soulbeasts");

            migrationBuilder.DropIndex(
                name: "IX_Soulbeasts_SoulbeastSkillId",
                table: "Soulbeasts");

            migrationBuilder.DropColumn(
                name: "SoulbeastSkillId",
                table: "Soulbeasts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SoulbeastSkillId",
                table: "Soulbeasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soulbeasts_SoulbeastSkillId",
                table: "Soulbeasts",
                column: "SoulbeastSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soulbeasts_SoulbeastSkills_SoulbeastSkillId",
                table: "Soulbeasts",
                column: "SoulbeastSkillId",
                principalTable: "SoulbeastSkills",
                principalColumn: "Id");
        }
    }
}
