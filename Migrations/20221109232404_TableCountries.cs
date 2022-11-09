using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class TableCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    cnt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cnt_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cnt_iso2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    cnt_iso3 = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    sta_id = table.Column<int>(type: "integer", nullable: false),
                    cnt_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cnt_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.cnt_id);
                    table.ForeignKey(
                        name: "FK_countries_status_sta_id",
                        column: x => x.sta_id,
                        principalTable: "status",
                        principalColumn: "sta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cnt_iso2",
                table: "countries",
                column: "cnt_iso2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cnt_iso3",
                table: "countries",
                column: "cnt_iso3",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cnt_name",
                table: "countries",
                column: "cnt_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_sta_id",
                table: "countries",
                column: "sta_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
