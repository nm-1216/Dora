using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180122_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_SyllabusFirstCourse",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    SyllabusId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_SyllabusFirstCourse", x => new { x.CourseId, x.SyllabusId });
                    table.ForeignKey(
                        name: "FK_School_SyllabusFirstCourse_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_SyllabusFirstCourse_School_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "School_Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusFirstCourse_SyllabusId",
                table: "School_SyllabusFirstCourse",
                column: "SyllabusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_SyllabusFirstCourse");
        }
    }
}
