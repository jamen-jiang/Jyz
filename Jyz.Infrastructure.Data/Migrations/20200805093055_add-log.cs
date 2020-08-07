using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jyz.Infrastructure.Data.Migrations
{
    public partial class addlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    LogOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 500, nullable: true),
                    Browser = table.Column<string>(maxLength: 200, nullable: true),
                    Os = table.Column<string>(maxLength: 200, nullable: true),
                    ElapsedMilliseconds = table.Column<long>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false),
                    ApiName = table.Column<string>(maxLength: 50, nullable: false),
                    ApiUrl = table.Column<string>(maxLength: 50, nullable: false),
                    ApiMethod = table.Column<string>(maxLength: 50, nullable: true),
                    Request = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
