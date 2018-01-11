using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180111_hwx_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "index",
                table: "AspNetRoles",
                newName: "Index");

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "School_ModuleType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "School_ModuleType");

            migrationBuilder.RenameColumn(
                name: "Index",
                table: "AspNetRoles",
                newName: "index");
        }
    }
}
