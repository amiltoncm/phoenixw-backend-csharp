using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class TablePersonTypes : Migration
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

            migrationBuilder.CreateIndex(
                name: "idx_pet_name",
                table: "person_types",
                column: "pet_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person_types");
        }
    }
}
