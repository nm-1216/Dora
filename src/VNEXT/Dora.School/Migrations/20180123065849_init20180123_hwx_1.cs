using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180123_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "School_TeachingTaskDetail");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "School_TeachingTaskDetail");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ClassId",
                table: "School_TeachingTaskDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "School_TeachingTaskDetail",
                nullable: true);
        }
    }
}
