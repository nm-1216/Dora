using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init12311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BOB",
                table: "School_Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BOB",
                table: "School_Student",
                nullable: true);
        }
    }
}
