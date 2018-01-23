using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180122_hwx_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_SyllabusTeacher",
                columns: table => new
                {
                    TeacherId = table.Column<string>(nullable: false),
                    SyllabusId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_SyllabusTeacher", x => new { x.TeacherId, x.SyllabusId });
                    table.ForeignKey(
                        name: "FK_School_SyllabusTeacher_School_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "School_Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_SyllabusTeacher_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusTeacher_SyllabusId",
                table: "School_SyllabusTeacher",
                column: "SyllabusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_SyllabusTeacher");
        }
    }
}
