using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180117_hwx_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingTask_School_Course_CourseId",
                table: "School_TeachingTask");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingTask_School_Teacher_TeacherId",
                table: "School_TeachingTask");

            migrationBuilder.DropIndex(
                name: "IX_School_TeachingTask_CourseId",
                table: "School_TeachingTask");

            migrationBuilder.DropIndex(
                name: "IX_School_TeachingTask_TeacherId",
                table: "School_TeachingTask");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "School_TeachingTask");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "School_TeachingTask");

            migrationBuilder.CreateTable(
                name: "School_TeachingTaskClass",
                columns: table => new
                {
                    TeachingTaskId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingTaskClass", x => new { x.TeachingTaskId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_School_TeachingTaskClass_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_TeachingTaskClass_School_TeachingTask_TeachingTaskId",
                        column: x => x.TeachingTaskId,
                        principalTable: "School_TeachingTask",
                        principalColumn: "TeachingTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingTaskTeacher",
                columns: table => new
                {
                    TeachingTaskId = table.Column<string>(nullable: false),
                    TeacherId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingTaskTeacher", x => new { x.TeachingTaskId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_School_TeachingTaskTeacher_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_TeachingTaskTeacher_School_TeachingTask_TeachingTaskId",
                        column: x => x.TeachingTaskId,
                        principalTable: "School_TeachingTask",
                        principalColumn: "TeachingTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTaskClass_CourseId",
                table: "School_TeachingTaskClass",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTaskTeacher_TeacherId",
                table: "School_TeachingTaskTeacher",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_TeachingTaskClass");

            migrationBuilder.DropTable(
                name: "School_TeachingTaskTeacher");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "School_TeachingTask",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "School_TeachingTask",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTask_CourseId",
                table: "School_TeachingTask",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTask_TeacherId",
                table: "School_TeachingTask",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingTask_School_Course_CourseId",
                table: "School_TeachingTask",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingTask_School_Teacher_TeacherId",
                table: "School_TeachingTask",
                column: "TeacherId",
                principalTable: "School_Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
