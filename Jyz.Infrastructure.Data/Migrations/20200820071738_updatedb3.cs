using Microsoft.EntityFrameworkCore.Migrations;

namespace Jyz.Infrastructure.Data.Migrations
{
    public partial class updatedb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Organization",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Organization",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
