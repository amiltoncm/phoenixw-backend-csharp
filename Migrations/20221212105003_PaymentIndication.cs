using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class PaymentIndication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment_indications",
                columns: table => new
                {
                    pin_id = table.Column<int>(type: "integer", nullable: false),
                    pin_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_indications", x => x.pin_id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_pin_name",
                table: "payment_indications",
                column: "pin_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_indications");
        }
    }
}
