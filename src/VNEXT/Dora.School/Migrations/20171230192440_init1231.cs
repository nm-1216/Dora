using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init1231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_School_Teacher_TeacherId",
                table: "School_Teacher");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusPeriod_SyllabusId",
                table: "School_SyllabusPeriod");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusLog_SyllabusId",
                table: "School_SyllabusLog");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusBook_SyllabusId",
                table: "School_SyllabusBook");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusApproval_SyllabusId",
                table: "School_SyllabusApproval");

            migrationBuilder.DropIndex(
                name: "IX_School_Student_StudentId",
                table: "School_Student");

            migrationBuilder.DropIndex(
                name: "IX_School_CourseProfessional_CourseId",
                table: "School_CourseProfessional");

            migrationBuilder.DropIndex(
                name: "IX_School_CourseClassTeacher_ClassId",
                table: "School_CourseClassTeacher");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "School_Teacher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "School_Student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "School_Teacher");

            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "School_Student");

            migrationBuilder.CreateIndex(
                name: "IX_School_Teacher_TeacherId",
                table: "School_Teacher",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusPeriod_SyllabusId",
                table: "School_SyllabusPeriod",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusLog_SyllabusId",
                table: "School_SyllabusLog",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusBook_SyllabusId",
                table: "School_SyllabusBook",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusApproval_SyllabusId",
                table: "School_SyllabusApproval",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Student_StudentId",
                table: "School_Student",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseProfessional_CourseId",
                table: "School_CourseProfessional",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseClassTeacher_ClassId",
                table: "School_CourseClassTeacher",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
