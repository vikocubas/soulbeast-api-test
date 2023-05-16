using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class asdosand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoulbeastSkills",
                table: "SoulbeastSkills");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SoulbeastSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoulbeastSkills",
                table: "SoulbeastSkills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SoulbeastSkills_SoulbeastId",
                table: "SoulbeastSkills",
                column: "SoulbeastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoulbeastSkills",
                table: "SoulbeastSkills");

            migrationBuilder.DropIndex(
                name: "IX_SoulbeastSkills_SoulbeastId",
                table: "SoulbeastSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SoulbeastSkills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoulbeastSkills",
                table: "SoulbeastSkills",
                columns: new[] { "SoulbeastId", "SkillId" });
        }
    }
}
