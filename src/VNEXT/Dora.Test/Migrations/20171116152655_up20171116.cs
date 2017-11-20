using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dora.Test.Migrations
{
    public partial class up20171116 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "School_Grade",
                columns: table => new
                {
                    GradeId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Grade", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "School_User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UserType = table.Column<int>(maxLength: 256, nullable: false),
                    WxAvatar = table.Column<string>(maxLength: 256, nullable: true),
                    WxName = table.Column<string>(maxLength: 256, nullable: true),
                    WxOpenId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "School_Class",
                columns: table => new
                {
                    ClassId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    InviteCode = table.Column<string>(maxLength: 256, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Class", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_School_Class_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_UserInClass",
                columns: table => new
                {
                    ClassId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_UserInClass", x => new { x.ClassId, x.UserId });
                    table.ForeignKey(
                        name: "FK_School_UserInClass_School_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_UserInClass_School_User_UserId",
                        column: x => x.UserId,
                        principalTable: "School_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_Class_CourseId",
                table: "School_Class",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_UserInClass_ClassId",
                table: "School_UserInClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_UserInClass_UserId",
                table: "School_UserInClass",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_Grade");

            migrationBuilder.DropTable(
                name: "School_UserInClass");

            migrationBuilder.DropTable(
                name: "School_Class");

            migrationBuilder.DropTable(
                name: "School_User");

            migrationBuilder.DropTable(
                name: "School_Course");
        }
    }
}
