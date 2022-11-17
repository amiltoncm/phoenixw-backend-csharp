﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person_types",
                columns: table => new
                {
                    pet_id = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    pet_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_types", x => x.pet_id);
                });

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
                name: "public_places",
                columns: table => new
                {
                    pup_id = table.Column<int>(type: "integer", nullable: false),
                    pup_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_public_places", x => x.pup_id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    sta_id = table.Column<int>(type: "integer", nullable: false),
                    sta_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.sta_id);
                });

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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    usr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usr_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    usr_email = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    usr_password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    ste_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ste_code = table.Column<int>(type: "integer", nullable: false),
                    ste_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ste_abbreviation = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cti_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cti_code = table.Column<int>(type: "integer", nullable: false),
                    cti_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "idx_pet_name",
                table: "person_types",
                column: "pet_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_pro_name",
                table: "profiles",
                column: "pro_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_pup_name",
                table: "public_places",
                column: "pup_name",
                unique: true);

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
                name: "cities");

            migrationBuilder.DropTable(
                name: "person_types");

            migrationBuilder.DropTable(
                name: "public_places");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "status");
        }
    }
}
