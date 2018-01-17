using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180117_hwx_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "School_Professional",
                newName: "Years");

            migrationBuilder.AddColumn<int>(
                name: "Gread",
                table: "School_Professional",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gread",
                table: "School_Professional");

            migrationBuilder.RenameColumn(
                name: "Years",
                table: "School_Professional",
                newName: "Year");
        }
    }
}
