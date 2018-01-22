using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180122_hwx_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_SyllabusProfessional",
                columns: table => new
                {
                    ProfessionalId = table.Column<string>(nullable: false),
                    SyllabusId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_SyllabusProfessional", x => new { x.ProfessionalId, x.SyllabusId });
                    table.ForeignKey(
                        name: "FK_School_SyllabusProfessional_School_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "School_Professional",
                        principalColumn: "ProfessionalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_SyllabusProfessional_School_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "School_Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusProfessional_SyllabusId",
                table: "School_SyllabusProfessional",
                column: "SyllabusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_SyllabusProfessional");
        }
    }
}
