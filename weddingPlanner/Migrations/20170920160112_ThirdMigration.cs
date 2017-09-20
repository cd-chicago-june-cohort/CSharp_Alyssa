using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace weddingPlanner.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_SpouseOneId",
                table: "Weddings");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_SpouseTwoId",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_SpouseOneId",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_SpouseTwoId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "SpouseOneId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "SpouseTwoId",
                table: "Weddings");

            migrationBuilder.AddColumn<string>(
                name: "SpouseOne",
                table: "Weddings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpouseTwo",
                table: "Weddings",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpouseOne",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "SpouseTwo",
                table: "Weddings");

            migrationBuilder.AddColumn<int>(
                name: "SpouseOneId",
                table: "Weddings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpouseTwoId",
                table: "Weddings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_SpouseOneId",
                table: "Weddings",
                column: "SpouseOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_SpouseTwoId",
                table: "Weddings",
                column: "SpouseTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_SpouseOneId",
                table: "Weddings",
                column: "SpouseOneId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_SpouseTwoId",
                table: "Weddings",
                column: "SpouseTwoId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
