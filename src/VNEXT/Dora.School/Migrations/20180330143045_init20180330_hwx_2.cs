using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180330_hwx_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "School_LearnLogs");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "School_LearnLogs",
                newName: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "School_LearnLogs",
                newName: "CourseId");

            migrationBuilder.AddColumn<string>(
                name: "ClassId",
                table: "School_LearnLogs",
                nullable: true);
        }
    }
}
