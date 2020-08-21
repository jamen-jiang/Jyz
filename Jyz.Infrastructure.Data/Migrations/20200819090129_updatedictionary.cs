using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jyz.Infrastructure.Data.Migrations
{
    public partial class updatedictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PId",
                table: "Dictionary",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PId",
                table: "Dictionary",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
