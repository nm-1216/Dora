using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dora.school.Migrations
{
    public partial class init1224 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouAbs",
                table: "School_Course");

            migrationBuilder.DropColumn(
                name: "CouNat",
                table: "School_Course");

            migrationBuilder.DropColumn(
                name: "CouType",
                table: "School_Course");

            migrationBuilder.AddColumn<string>(
                name: "BOB",
                table: "School_Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "School_Professional",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "School_PersonnelTrainingApproval",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "School_Course",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nature",
                table: "School_Course",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "School_Course",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Section",
                table: "School_TeachingTaskDetail",
                nullable: false);

            migrationBuilder.AlterColumn<float>(
                name: "Period",
                table: "School_Course",
                nullable: false);

            migrationBuilder.AlterColumn<float>(
                name: "Credit",
                table: "School_Course",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BOB",
                table: "School_Student");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "School_Professional");

            migrationBuilder.DropColumn(
                name: "File",
                table: "School_PersonnelTrainingApproval");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "School_Course");

            migrationBuilder.DropColumn(
                name: "Nature",
                table: "School_Course");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "School_Course");

            migrationBuilder.AddColumn<string>(
                name: "CouAbs",
                table: "School_Course",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CouNat",
                table: "School_Course",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CouType",
                table: "School_Course",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Section",
                table: "School_TeachingTaskDetail",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Period",
                table: "School_Course",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Credit",
                table: "School_Course",
                nullable: true);
        }
    }
}
