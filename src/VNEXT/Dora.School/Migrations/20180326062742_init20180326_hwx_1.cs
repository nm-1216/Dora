using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180326_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "School_Papers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_Papers_TeacherId",
                table: "School_Papers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Papers_School_Teacher_TeacherId",
                table: "School_Papers",
                column: "TeacherId",
                principalTable: "School_Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Papers_School_Teacher_TeacherId",
                table: "School_Papers");

            migrationBuilder.DropIndex(
                name: "IX_School_Papers_TeacherId",
                table: "School_Papers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "School_Papers");
        }
    }
}
