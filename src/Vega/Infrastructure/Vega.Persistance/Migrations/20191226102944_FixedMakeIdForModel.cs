using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Persistance.Migrations
{
    public partial class FixedMakeIdForModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeId1",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_MakeId1",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "MakeId1",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Models");

            migrationBuilder.AddColumn<Guid>(
                name: "MakeId",
                table: "Models",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_MakeId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Models");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Models",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MakeId1",
                table: "Models",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId1",
                table: "Models",
                column: "MakeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeId1",
                table: "Models",
                column: "MakeId1",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
