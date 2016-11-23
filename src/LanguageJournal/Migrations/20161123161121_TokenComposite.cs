using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageJournal.Migrations
{
    public partial class TokenComposite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tokens",
                nullable: false,
                oldClrType: typeof(string))
                .OldAnnotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                columns: new[] { "UserId", "Value" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tokens",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");
        }
    }
}
