using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jyz.Infrastructure.Data.Migrations
{
    public partial class add_loglogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Log");

            migrationBuilder.RenameTable(
                name: "Log",
                newName: "LogOperate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogOperate",
                table: "LogOperate",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LogLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    LoginOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 500, nullable: true),
                    Browser = table.Column<string>(maxLength: 200, nullable: true),
                    Os = table.Column<string>(maxLength: 200, nullable: true),
                    IsSuccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLogin", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogOperate",
                table: "LogOperate");

            migrationBuilder.RenameTable(
                name: "LogOperate",
                newName: "Log");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Log",
                column: "Id");
        }
    }
}
