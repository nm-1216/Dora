using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180228_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingPlan_School_Classes_ClassId",
                table: "School_TeachingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TeachingPlan_School_Teacher_TeacherId",
                table: "School_TeachingPlan");

            migrationBuilder.DropIndex(
                name: "IX_School_TeachingPlan_ClassId",
                table: "School_TeachingPlan");

            migrationBuilder.DropIndex(
                name: "IX_School_TeachingPlan_TeacherId",
                table: "School_TeachingPlan");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "School_TeachingPlan");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "School_TeachingPlan",
                newName: "TeachingTaskId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPush",
                table: "School_TeachingTask",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TeachingTaskId",
                table: "School_TeachingPlan",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "School_TeachingPlanClass",
                columns: table => new
                {
                    TeachingPlanId = table.Column<string>(nullable: false),
                    ClassId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingPlanClass", x => new { x.TeachingPlanId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanClass_School_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanClass_School_TeachingPlan_TeachingPlanId",
                        column: x => x.TeachingPlanId,
                        principalTable: "School_TeachingPlan",
                        principalColumn: "TeachingPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingPlanTeacher",
                columns: table => new
                {
                    TeachingPlanId = table.Column<string>(nullable: false),
                    TeacherId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingPlanTeacher", x => new { x.TeachingPlanId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanTeacher_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanTeacher_School_TeachingPlan_TeachingPlanId",
                        column: x => x.TeachingPlanId,
                        principalTable: "School_TeachingPlan",
                        principalColumn: "TeachingPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlanClass_ClassId",
                table: "School_TeachingPlanClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlanTeacher_TeacherId",
                table: "School_TeachingPlanTeacher",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_TeachingPlanClass");

            migrationBuilder.DropTable(
                name: "School_TeachingPlanTeacher");

            migrationBuilder.DropColumn(
                name: "IsPush",
                table: "School_TeachingTask");

            migrationBuilder.RenameColumn(
                name: "TeachingTaskId",
                table: "School_TeachingPlan",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "School_TeachingPlan",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassId",
                table: "School_TeachingPlan",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlan_ClassId",
                table: "School_TeachingPlan",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlan_TeacherId",
                table: "School_TeachingPlan",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingPlan_School_Classes_ClassId",
                table: "School_TeachingPlan",
                column: "ClassId",
                principalTable: "School_Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TeachingPlan_School_Teacher_TeacherId",
                table: "School_TeachingPlan",
                column: "TeacherId",
                principalTable: "School_Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
