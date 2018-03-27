using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init3123123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_CourseProfessional_School_Course_CourseId",
                table: "School_CourseProfessional");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Syllabus_School_Course_CourseId",
                table: "School_Syllabus");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusFirstCourse_School_Course_CourseId",
                table: "School_SyllabusFirstCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingPlan_School_Course_CourseId",
                table: "School_TeachingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingTask_School_Course_CourseId",
                table: "School_TeachingTask");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TrainingPlan_School_Course_CourseId",
                table: "School_TrainingPlan");

            migrationBuilder.DropTable(
                name: "School_Course");

            migrationBuilder.CreateTable(
                name: "School_Course1",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    AppLev = table.Column<string>(maxLength: 256, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Credit = table.Column<float>(nullable: false),
                    Discription = table.Column<string>(maxLength: 4000, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Nature = table.Column<string>(maxLength: 256, nullable: false),
                    OrganizationId = table.Column<string>(nullable: true),
                    Period = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Course1", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_School_Course1_School_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_Course1_OrganizationId",
                table: "School_Course1",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_CourseProfessional_School_Course1_CourseId",
                table: "School_CourseProfessional",
                column: "CourseId",
                principalTable: "School_Course1",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Syllabus_School_Course1_CourseId",
                table: "School_Syllabus",
                column: "CourseId",
                principalTable: "School_Course1",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusFirstCourse_School_Course1_CourseId",
                table: "School_SyllabusFirstCourse",
                column: "CourseId",
                principalTable: "School_Course1",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingPlan_School_Course1_CourseId",
                table: "School_TeachingPlan",
                column: "CourseId",
                principalTable: "School_Course1",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingTask_School_Course1_CourseId",
                table: "School_TeachingTask",
                column: "CourseId",
                principalTable: "School_Course1",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TrainingPlan_School_Course1_CourseId",
                table: "School_TrainingPlan",
                column: "CourseId",
                principalTable: "School_Course1",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_CourseProfessional_School_Course1_CourseId",
                table: "School_CourseProfessional");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Syllabus_School_Course1_CourseId",
                table: "School_Syllabus");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusFirstCourse_School_Course1_CourseId",
                table: "School_SyllabusFirstCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingPlan_School_Course1_CourseId",
                table: "School_TeachingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingTask_School_Course1_CourseId",
                table: "School_TeachingTask");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TrainingPlan_School_Course1_CourseId",
                table: "School_TrainingPlan");

            migrationBuilder.DropTable(
                name: "School_Course1");

            migrationBuilder.CreateTable(
                name: "School_Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    AppLev = table.Column<string>(maxLength: 256, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Credit = table.Column<float>(nullable: false),
                    Discription = table.Column<string>(maxLength: 4000, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Nature = table.Column<string>(maxLength: 256, nullable: false),
                    OrganizationId = table.Column<string>(nullable: true),
                    Period = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_School_Course_School_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_Course_OrganizationId",
                table: "School_Course",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_CourseProfessional_School_Course_CourseId",
                table: "School_CourseProfessional",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Syllabus_School_Course_CourseId",
                table: "School_Syllabus",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusFirstCourse_School_Course_CourseId",
                table: "School_SyllabusFirstCourse",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingPlan_School_Course_CourseId",
                table: "School_TeachingPlan",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingTask_School_Course_CourseId",
                table: "School_TeachingTask",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TrainingPlan_School_Course_CourseId",
                table: "School_TrainingPlan",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
