using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class TableCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cti_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cti_code = table.Column<int>(type: "integer", nullable: false),
                    cti_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ste_id = table.Column<int>(type: "integer", nullable: false),
                    sta_id = table.Column<int>(type: "integer", nullable: false),
                    cti_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cti_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cti_id);
                    table.ForeignKey(
                        name: "FK_cities_states_ste_id",
                        column: x => x.ste_id,
                        principalTable: "states",
                        principalColumn: "ste_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cities_status_sta_id",
                        column: x => x.sta_id,
                        principalTable: "status",
                        principalColumn: "sta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cti_name",
                table: "cities",
                column: "cti_name");

            migrationBuilder.CreateIndex(
                name: "IX_cities_sta_id",
                table: "cities",
                column: "sta_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_ste_id",
                table: "cities",
                column: "ste_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
