using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    /// <inheritdoc />
    public partial class feaif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SoulbeastId",
                table: "SoulbeastSkills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_SoulbeastSkills_SoulbeastId",
                table: "SoulbeastSkills",
                column: "SoulbeastId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoulbeastSkills_Soulbeasts_SoulbeastId",
                table: "SoulbeastSkills",
                column: "SoulbeastId",
                principalTable: "Soulbeasts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoulbeastSkills_Soulbeasts_SoulbeastId",
                table: "SoulbeastSkills");

            migrationBuilder.DropIndex(
                name: "IX_SoulbeastSkills_SoulbeastId",
                table: "SoulbeastSkills");

            migrationBuilder.AlterColumn<Guid>(
                name: "SoulbeastId",
                table: "SoulbeastSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
