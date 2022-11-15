using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class TablePublicPlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "idx_pup_name",
                table: "public_places",
                column: "pup_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "public_places");
        }
    }
}
