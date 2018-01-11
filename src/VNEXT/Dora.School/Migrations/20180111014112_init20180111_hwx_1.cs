using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180111_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Permission_School_Module_ModuleId",
                table: "School_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Permission_AspNetRoles_RoleId",
                table: "School_Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_Permission",
                table: "School_Permission");

            migrationBuilder.DropIndex(
                name: "IX_School_Permission_ModuleId",
                table: "School_Permission");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "School_Permission");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "School_Permission");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "School_Permission",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModuleTypeId",
                table: "School_Permission",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "index",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_Permission",
                table: "School_Permission",
                columns: new[] { "ModuleTypeId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_School_Permission_School_ModuleType_ModuleTypeId",
                table: "School_Permission",
                column: "ModuleTypeId",
                principalTable: "School_ModuleType",
                principalColumn: "ModuleTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Permission_AspNetRoles_RoleId",
                table: "School_Permission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Permission_School_ModuleType_ModuleTypeId",
                table: "School_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Permission_AspNetRoles_RoleId",
                table: "School_Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School_Permission",
                table: "School_Permission");

            migrationBuilder.DropColumn(
                name: "ModuleTypeId",
                table: "School_Permission");

            migrationBuilder.DropColumn(
                name: "index",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "School_Permission",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PermissionId",
                table: "School_Permission",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModuleId",
                table: "School_Permission",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_School_Permission",
                table: "School_Permission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Permission_ModuleId",
                table: "School_Permission",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Permission_School_Module_ModuleId",
                table: "School_Permission",
                column: "ModuleId",
                principalTable: "School_Module",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Permission_AspNetRoles_RoleId",
                table: "School_Permission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
