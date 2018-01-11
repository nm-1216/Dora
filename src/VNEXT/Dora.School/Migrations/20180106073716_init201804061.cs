using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init201804061 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetGroups",
                columns: table => new
                {
                    GroupId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 128, nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_AspNetGroups_AspNetGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AspNetGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetGroups_ParentId",
                table: "AspNetGroups",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetGroups");
        }
    }
}
