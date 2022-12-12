using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class PaymentTermMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment_terms",
                columns: table => new
                {
                    pyt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pyt_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    pyt_installments = table.Column<int>(type: "integer", nullable: false),
                    pyt_periods = table.Column<int>(type: "integer", nullable: false),
                    pyt_fees = table.Column<float>(type: "real", nullable: false),
                    pin_id = table.Column<int>(type: "integer", nullable: false),
                    pty_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pty_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_terms", x => x.pyt_id);
                    table.ForeignKey(
                        name: "FK_payment_terms_payment_indications_pin_id",
                        column: x => x.pin_id,
                        principalTable: "payment_indications",
                        principalColumn: "pin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_term_methods",
                columns: table => new
                {
                    pyt_id = table.Column<int>(type: "integer", nullable: false),
                    pay_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_term_methods", x => new { x.pyt_id, x.pay_id });
                    table.ForeignKey(
                        name: "FK_payment_term_methods_payment_methods_pay_id",
                        column: x => x.pay_id,
                        principalTable: "payment_methods",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payment_term_methods_payment_terms_pyt_id",
                        column: x => x.pyt_id,
                        principalTable: "payment_terms",
                        principalColumn: "pyt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_term_methods_pay_id",
                table: "payment_term_methods",
                column: "pay_id");

            migrationBuilder.CreateIndex(
                name: "idx_pyt_name",
                table: "payment_terms",
                column: "pyt_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payment_terms_pin_id",
                table: "payment_terms",
                column: "pin_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_term_methods");

            migrationBuilder.DropTable(
                name: "payment_terms");
        }
    }
}
