using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180112_hwx_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BefCouCode1",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "BefCouCode2",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "BefCouCode3",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "BefCouCode4",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "BefCouCode5",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "BefCouName1",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "BefCouName2",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "BefCouName3",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "SubTime",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "UseSta",
                table: "School_Syllabus");

            migrationBuilder.RenameColumn(
                name: "BefCouName5",
                table: "School_Syllabus",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "BefCouName4",
                table: "School_Syllabus",
                newName: "GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "School_Syllabus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "School_Syllabus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_Syllabus_GroupId",
                table: "School_Syllabus",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Syllabus_TeacherId",
                table: "School_Syllabus",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Syllabus_AspNetGroups_GroupId",
                table: "School_Syllabus",
                column: "GroupId",
                principalTable: "AspNetGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Syllabus_School_Teacher_TeacherId",
                table: "School_Syllabus",
                column: "TeacherId",
                principalTable: "School_Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Syllabus_AspNetGroups_GroupId",
                table: "School_Syllabus");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Syllabus_School_Teacher_TeacherId",
                table: "School_Syllabus");

            migrationBuilder.DropIndex(
                name: "IX_School_Syllabus_GroupId",
                table: "School_Syllabus");

            migrationBuilder.DropIndex(
                name: "IX_School_Syllabus_TeacherId",
                table: "School_Syllabus");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "School_Syllabus",
                newName: "BefCouName5");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "School_Syllabus",
                newName: "BefCouName4");

            migrationBuilder.AlterColumn<string>(
                name: "BefCouName5",
                table: "School_Syllabus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BefCouName4",
                table: "School_Syllabus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouCode1",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouCode2",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouCode3",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouCode4",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouCode5",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouName1",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouName2",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BefCouName3",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubTime",
                table: "School_Syllabus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseSta",
                table: "School_Syllabus",
                nullable: true);
        }
    }
}
