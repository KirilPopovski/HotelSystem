using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelSystem.Statistics.Data.Migrations
{
    public partial class ChangeFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Feedbacks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
