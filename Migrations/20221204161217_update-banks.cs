using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class updatebanks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "bnk_created",
                table: "banks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "bnk_updated",
                table: "banks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "sta_id",
                table: "banks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_banks_sta_id",
                table: "banks",
                column: "sta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_banks_status_sta_id",
                table: "banks",
                column: "sta_id",
                principalTable: "status",
                principalColumn: "sta_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banks_status_sta_id",
                table: "banks");

            migrationBuilder.DropIndex(
                name: "IX_banks_sta_id",
                table: "banks");

            migrationBuilder.DropColumn(
                name: "bnk_created",
                table: "banks");

            migrationBuilder.DropColumn(
                name: "bnk_updated",
                table: "banks");

            migrationBuilder.DropColumn(
                name: "sta_id",
                table: "banks");
        }
    }
}
