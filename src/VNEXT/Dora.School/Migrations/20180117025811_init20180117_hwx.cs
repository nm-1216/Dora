using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180117_hwx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Syllabus_AspNetGroups_GroupId",
                table: "School_Syllabus");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "School_Syllabus",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_School_Syllabus_GroupId",
                table: "School_Syllabus",
                newName: "IX_School_Syllabus_OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Syllabus_School_Organization_OrganizationId",
                table: "School_Syllabus",
                column: "OrganizationId",
                principalTable: "School_Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Syllabus_School_Organization_OrganizationId",
                table: "School_Syllabus");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "School_Syllabus",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_School_Syllabus_OrganizationId",
                table: "School_Syllabus",
                newName: "IX_School_Syllabus_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Syllabus_AspNetGroups_GroupId",
                table: "School_Syllabus",
                column: "GroupId",
                principalTable: "AspNetGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
