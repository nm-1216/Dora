using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180120_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusApproval_School_Syllabus_SyllabusId",
                table: "School_SyllabusApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusBook_School_Syllabus_SyllabusId",
                table: "School_SyllabusBook");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusLog_School_Syllabus_SyllabusId",
                table: "School_SyllabusLog");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusPeriod_School_Syllabus_SyllabusId",
                table: "School_SyllabusPeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusPeriod",
                table: "School_SyllabusPeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusLog",
                table: "School_SyllabusLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusBook",
                table: "School_SyllabusBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusApproval",
                table: "School_SyllabusApproval");

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusPeriodId",
                table: "School_SyllabusPeriod",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusPeriod",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusLogId",
                table: "School_SyllabusLog",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusLog",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusBookId",
                table: "School_SyllabusBook",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusBook",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusApprovalId",
                table: "School_SyllabusApproval",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusApproval",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusPeriod",
                table: "School_SyllabusPeriod",
                column: "SyllabusPeriodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusLog",
                table: "School_SyllabusLog",
                column: "SyllabusLogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusBook",
                table: "School_SyllabusBook",
                column: "SyllabusBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusApproval",
                table: "School_SyllabusApproval",
                column: "SyllabusApprovalId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusApproval_School_Syllabus_SyllabusId",
                table: "School_SyllabusApproval",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusBook_School_Syllabus_SyllabusId",
                table: "School_SyllabusBook",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusLog_School_Syllabus_SyllabusId",
                table: "School_SyllabusLog",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusPeriod_School_Syllabus_SyllabusId",
                table: "School_SyllabusPeriod",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusApproval_School_Syllabus_SyllabusId",
                table: "School_SyllabusApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusBook_School_Syllabus_SyllabusId",
                table: "School_SyllabusBook");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusLog_School_Syllabus_SyllabusId",
                table: "School_SyllabusLog");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SyllabusPeriod_School_Syllabus_SyllabusId",
                table: "School_SyllabusPeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusPeriod",
                table: "School_SyllabusPeriod");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusPeriod_SyllabusId",
                table: "School_SyllabusPeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusLog",
                table: "School_SyllabusLog");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusLog_SyllabusId",
                table: "School_SyllabusLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusBook",
                table: "School_SyllabusBook");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusBook_SyllabusId",
                table: "School_SyllabusBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_SyllabusApproval",
                table: "School_SyllabusApproval");

            migrationBuilder.DropIndex(
                name: "IX_School_SyllabusApproval_SyllabusId",
                table: "School_SyllabusApproval");

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusPeriod",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusPeriodId",
                table: "School_SyllabusPeriod",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusLog",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusLogId",
                table: "School_SyllabusLog",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusBook",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusBookId",
                table: "School_SyllabusBook",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusId",
                table: "School_SyllabusApproval",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SyllabusApprovalId",
                table: "School_SyllabusApproval",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusPeriod",
                table: "School_SyllabusPeriod",
                column: "SyllabusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusLog",
                table: "School_SyllabusLog",
                column: "SyllabusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusBook",
                table: "School_SyllabusBook",
                column: "SyllabusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_SyllabusApproval",
                table: "School_SyllabusApproval",
                column: "SyllabusId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusApproval_School_Syllabus_SyllabusId",
                table: "School_SyllabusApproval",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusBook_School_Syllabus_SyllabusId",
                table: "School_SyllabusBook",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusLog_School_Syllabus_SyllabusId",
                table: "School_SyllabusLog",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SyllabusPeriod_School_Syllabus_SyllabusId",
                table: "School_SyllabusPeriod",
                column: "SyllabusId",
                principalTable: "School_Syllabus",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
