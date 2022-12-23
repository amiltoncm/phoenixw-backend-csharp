using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class TableAdressTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address_types",
                columns: table => new
                {
                    adt_id = table.Column<int>(type: "integer", nullable: false),
                    adt_name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_types", x => x.adt_id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_adt_name",
                table: "address_types",
                column: "adt_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address_types");
        }
    }
}
