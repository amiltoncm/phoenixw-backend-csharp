using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class InitialCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pro_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.pro_id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    sta_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sta_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.sta_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    usr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usr_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    usr_email = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    usr_password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    pro_id = table.Column<int>(type: "integer", nullable: false),
                    sta_id = table.Column<int>(type: "integer", nullable: false),
                    usr_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usr_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usr_deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.usr_id);
                    table.ForeignKey(
                        name: "FK_users_profiles_pro_id",
                        column: x => x.pro_id,
                        principalTable: "profiles",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_status_sta_id",
                        column: x => x.sta_id,
                        principalTable: "status",
                        principalColumn: "sta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_pro_name",
                table: "profiles",
                column: "pro_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_sta_name",
                table: "status",
                column: "sta_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_usr_name",
                table: "users",
                column: "usr_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_pro_id",
                table: "users",
                column: "pro_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_sta_id",
                table: "users",
                column: "sta_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "status");
        }
    }
}
