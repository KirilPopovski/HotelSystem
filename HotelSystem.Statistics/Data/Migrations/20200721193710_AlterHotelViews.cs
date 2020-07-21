using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelSystem.Statistics.Data.Migrations
{
    public partial class AlterHotelViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HotelViews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
