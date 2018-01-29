using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180129_hwx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_PersonnelTraining_School_Organization_OrganizationId",
                table: "School_PersonnelTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingTaskClass_School_Course_CourseId",
                table: "School_TeachingTaskClass");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "School_TeachingTaskClass",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_School_TeachingTaskClass_CourseId",
                table: "School_TeachingTaskClass",
                newName: "IX_School_TeachingTaskClass_ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationId",
                table: "School_PersonnelTraining",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_School_PersonnelTraining_School_Organization_OrganizationId",
                table: "School_PersonnelTraining",
                column: "OrganizationId",
                principalTable: "School_Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingTaskClass_School_Classes_ClassId",
                table: "School_TeachingTaskClass",
                column: "ClassId",
                principalTable: "School_Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_PersonnelTraining_School_Organization_OrganizationId",
                table: "School_PersonnelTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingTaskClass_School_Classes_ClassId",
                table: "School_TeachingTaskClass");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "School_TeachingTaskClass",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_School_TeachingTaskClass_ClassId",
                table: "School_TeachingTaskClass",
                newName: "IX_School_TeachingTaskClass_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationId",
                table: "School_PersonnelTraining",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_School_PersonnelTraining_School_Organization_OrganizationId",
                table: "School_PersonnelTraining",
                column: "OrganizationId",
                principalTable: "School_Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingTaskClass_School_Course_CourseId",
                table: "School_TeachingTaskClass",
                column: "CourseId",
                principalTable: "School_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
