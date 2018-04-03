using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180403_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingPlanDetail_School_Teacher_TeacherId",
                table: "School_TeachingPlanDetail");

            migrationBuilder.DropIndex(
                name: "IX_School_TeachingPlanDetail_TeacherId",
                table: "School_TeachingPlanDetail");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "School_TeachingPlanDetail",
                newName: "Teacher");

            migrationBuilder.AlterColumn<string>(
                name: "Teacher",
                table: "School_TeachingPlanDetail",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Teacher",
                table: "School_TeachingPlanDetail",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "School_TeachingPlanDetail",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlanDetail_TeacherId",
                table: "School_TeachingPlanDetail",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingPlanDetail_School_Teacher_TeacherId",
                table: "School_TeachingPlanDetail",
                column: "TeacherId",
                principalTable: "School_Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
