using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180406 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_CourseClassTeacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_CourseClassTeacher",
                columns: table => new
                {
                    ClassId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    TeacherId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Term = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_CourseClassTeacher", x => new { x.ClassId, x.CourseId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_School_CourseClassTeacher_School_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_CourseClassTeacher_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_CourseClassTeacher_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseClassTeacher_CourseId",
                table: "School_CourseClassTeacher",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseClassTeacher_TeacherId",
                table: "School_CourseClassTeacher",
                column: "TeacherId");
        }
    }
}
