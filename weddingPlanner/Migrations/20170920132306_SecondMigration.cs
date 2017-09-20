using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace weddingPlanner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestConnection_Users_GuestId",
                table: "GuestConnection");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestConnection_Weddings_WeddingId",
                table: "GuestConnection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestConnection",
                table: "GuestConnection");

            migrationBuilder.RenameTable(
                name: "GuestConnection",
                newName: "GuestConnections");

            migrationBuilder.RenameIndex(
                name: "IX_GuestConnection_WeddingId",
                table: "GuestConnections",
                newName: "IX_GuestConnections_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestConnection_GuestId",
                table: "GuestConnections",
                newName: "IX_GuestConnections_GuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestConnections",
                table: "GuestConnections",
                column: "GuestConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestConnections_Users_GuestId",
                table: "GuestConnections",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestConnections_Weddings_WeddingId",
                table: "GuestConnections",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestConnections_Users_GuestId",
                table: "GuestConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestConnections_Weddings_WeddingId",
                table: "GuestConnections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestConnections",
                table: "GuestConnections");

            migrationBuilder.RenameTable(
                name: "GuestConnections",
                newName: "GuestConnection");

            migrationBuilder.RenameIndex(
                name: "IX_GuestConnections_WeddingId",
                table: "GuestConnection",
                newName: "IX_GuestConnection_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestConnections_GuestId",
                table: "GuestConnection",
                newName: "IX_GuestConnection_GuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestConnection",
                table: "GuestConnection",
                column: "GuestConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestConnection_Users_GuestId",
                table: "GuestConnection",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestConnection_Weddings_WeddingId",
                table: "GuestConnection",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
