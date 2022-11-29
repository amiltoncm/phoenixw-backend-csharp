using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Migrations
{
    public partial class UpdateBanks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bnk_code",
                table: "banks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bnk_code",
                table: "banks");
        }
    }
}
