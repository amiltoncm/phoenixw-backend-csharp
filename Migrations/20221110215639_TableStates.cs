using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class TableStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    ste_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ste_code = table.Column<int>(type: "integer", nullable: false),
                    ste_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ste_abbreviation = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cnt_id = table.Column<int>(type: "integer", nullable: false),
                    sta_id = table.Column<int>(type: "integer", nullable: false),
                    ste_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ste_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.ste_id);
                    table.ForeignKey(
                        name: "FK_states_countries_cnt_id",
                        column: x => x.cnt_id,
                        principalTable: "countries",
                        principalColumn: "cnt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_states_status_sta_id",
                        column: x => x.sta_id,
                        principalTable: "status",
                        principalColumn: "sta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_ste_name",
                table: "states",
                column: "ste_name");

            migrationBuilder.CreateIndex(
                name: "IX_states_cnt_id",
                table: "states",
                column: "cnt_id");

            migrationBuilder.CreateIndex(
                name: "IX_states_sta_id",
                table: "states",
                column: "sta_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "states");
        }
    }
}
