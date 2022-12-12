using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class UpdatePaymentTerms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sta_id",
                table: "payment_terms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_payment_terms_sta_id",
                table: "payment_terms",
                column: "sta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_payment_terms_status_sta_id",
                table: "payment_terms",
                column: "sta_id",
                principalTable: "status",
                principalColumn: "sta_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payment_terms_status_sta_id",
                table: "payment_terms");

            migrationBuilder.DropIndex(
                name: "IX_payment_terms_sta_id",
                table: "payment_terms");

            migrationBuilder.DropColumn(
                name: "sta_id",
                table: "payment_terms");
        }
    }
}
