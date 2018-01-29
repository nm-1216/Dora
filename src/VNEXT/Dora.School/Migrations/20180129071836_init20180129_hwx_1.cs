using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180129_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "School_TeachingTask",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTask_CourseId",
                table: "School_TeachingTask",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingTask_School_Course_CourseId",
                table: "School_TeachingTask",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingTask_School_Course_CourseId",
                table: "School_TeachingTask");

            migrationBuilder.DropIndex(
                name: "IX_School_TeachingTask_CourseId",
                table: "School_TeachingTask");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "School_TeachingTask");
        }
    }
}
