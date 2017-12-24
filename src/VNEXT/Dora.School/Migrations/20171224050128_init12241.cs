using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dora.school.Migrations
{
    public partial class init12241 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationId",
                table: "School_Professional",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_Professional_OrganizationId",
                table: "School_Professional",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Professional_School_Organization_OrganizationId",
                table: "School_Professional",
                column: "OrganizationId",
                principalTable: "School_Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Professional_School_Organization_OrganizationId",
                table: "School_Professional");

            migrationBuilder.DropIndex(
                name: "IX_School_Professional_OrganizationId",
                table: "School_Professional");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "School_Professional");
        }
    }
}
