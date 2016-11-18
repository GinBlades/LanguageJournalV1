using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageJournal.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Name = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Bio = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Value);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    UserLanguageId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    LanguageId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => x.UserLanguageId);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_UserId",
                table: "UserLanguages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
