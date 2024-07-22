using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCrm.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IntroduceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cursomers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursomers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Cursomers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marketers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FieldStudy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IrCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Education = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Marketers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursomers");

            migrationBuilder.DropTable(
                name: "Marketers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
