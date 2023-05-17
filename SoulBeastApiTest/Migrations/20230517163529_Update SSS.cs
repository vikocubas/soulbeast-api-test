using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSSS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoulbeastSkills_Skills_SkillId",
                table: "SoulbeastSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SoulbeastSkills_Soulbeasts_SoulbeastId",
                table: "SoulbeastSkills");

            migrationBuilder.DropIndex(
                name: "IX_SoulbeastSkills_SkillId",
                table: "SoulbeastSkills");

            migrationBuilder.DropIndex(
                name: "IX_SoulbeastSkills_SoulbeastId",
                table: "SoulbeastSkills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SoulbeastSkills_SkillId",
                table: "SoulbeastSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulbeastSkills_SoulbeastId",
                table: "SoulbeastSkills",
                column: "SoulbeastId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoulbeastSkills_Skills_SkillId",
                table: "SoulbeastSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoulbeastSkills_Soulbeasts_SoulbeastId",
                table: "SoulbeastSkills",
                column: "SoulbeastId",
                principalTable: "Soulbeasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
