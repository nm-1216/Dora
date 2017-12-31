using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dora.school.Migrations
{
    public partial class init122702 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "School_TrainingLab",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "School_TrainingLab");
        }
    }
}
