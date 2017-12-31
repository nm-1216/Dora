using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dora.school.Migrations
{
    public partial class init122501 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_TrainingLabDevice_TrainingLab_TrainingLabId",
                table: "School_TrainingLabDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TrainingPlanLog_TrainingLab_TrainingLabId",
                table: "School_TrainingPlanLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingLab",
                table: "TrainingLab");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "TrainingLab",
                maxLength: 64,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "School",
                table: "TrainingLab",
                maxLength: 256,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "RoomNo",
                table: "TrainingLab",
                maxLength: 256,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingLab",
                maxLength: 256,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastAction",
                table: "TrainingLab",
                maxLength: 64,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUser",
                table: "TrainingLab",
                maxLength: 64,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Center",
                table: "TrainingLab",
                maxLength: 256,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "BuildingNo",
                table: "TrainingLab",
                maxLength: 256,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Base",
                table: "TrainingLab",
                maxLength: 256,
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_TrainingLab",
                table: "TrainingLab",
                column: "TrainingLabId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_TrainingLabDevice_School_TrainingLab_TrainingLabId",
                table: "School_TrainingLabDevice",
                column: "TrainingLabId",
                principalTable: "TrainingLab",
                principalColumn: "TrainingLabId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TrainingPlanLog_School_TrainingLab_TrainingLabId",
                table: "School_TrainingPlanLog",
                column: "TrainingLabId",
                principalTable: "TrainingLab",
                principalColumn: "TrainingLabId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "TrainingLab",
                newName: "School_TrainingLab");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_TrainingLabDevice_School_TrainingLab_TrainingLabId",
                table: "School_TrainingLabDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_School_TrainingPlanLog_School_TrainingLab_TrainingLabId",
                table: "School_TrainingPlanLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_TrainingLab",
                table: "School_TrainingLab");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "School",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomNo",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastAction",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUser",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Center",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuildingNo",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Base",
                table: "School_TrainingLab",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingLab",
                table: "School_TrainingLab",
                column: "TrainingLabId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_TrainingLabDevice_TrainingLab_TrainingLabId",
                table: "School_TrainingLabDevice",
                column: "TrainingLabId",
                principalTable: "School_TrainingLab",
                principalColumn: "TrainingLabId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_TrainingPlanLog_TrainingLab_TrainingLabId",
                table: "School_TrainingPlanLog",
                column: "TrainingLabId",
                principalTable: "School_TrainingLab",
                principalColumn: "TrainingLabId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "School_TrainingLab",
                newName: "TrainingLab");
        }
    }
}
