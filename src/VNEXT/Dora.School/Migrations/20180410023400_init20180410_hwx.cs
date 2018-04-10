using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180410_hwx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaRoomCode",
                table: "School_TeachingTask");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "School_TeachingTask");

            migrationBuilder.DropColumn(
                name: "Week",
                table: "School_TeachingTask");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClaRoomCode",
                table: "School_TeachingTask",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Section",
                table: "School_TeachingTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Week",
                table: "School_TeachingTask",
                nullable: true);
        }
    }
}
