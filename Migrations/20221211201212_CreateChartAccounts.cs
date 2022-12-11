using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class CreateChartAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chart_accounts",
                columns: table => new
                {
                    cac_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cac_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    mvt_id = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cac_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cac_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sta_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chart_accounts", x => x.cac_id);
                    table.ForeignKey(
                        name: "FK_chart_accounts_moviment_types_mvt_id",
                        column: x => x.mvt_id,
                        principalTable: "moviment_types",
                        principalColumn: "mvt_id");
                    table.ForeignKey(
                        name: "FK_chart_accounts_status_sta_id",
                        column: x => x.sta_id,
                        principalTable: "status",
                        principalColumn: "sta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cac_name",
                table: "chart_accounts",
                column: "cac_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chart_accounts_mvt_id",
                table: "chart_accounts",
                column: "mvt_id");

            migrationBuilder.CreateIndex(
                name: "IX_chart_accounts_sta_id",
                table: "chart_accounts",
                column: "sta_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chart_accounts");
        }
    }
}
