using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180326_hwx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_Papers",
                columns: table => new
                {
                    PaperId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Papers", x => x.PaperId);
                });

            migrationBuilder.CreateTable(
                name: "School_PaperAnswers",
                columns: table => new
                {
                    PaperAnswerId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    PaperId = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_PaperAnswers", x => x.PaperAnswerId);
                    table.ForeignKey(
                        name: "FK_School_PaperAnswers_School_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "School_Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_PaperAnswers_School_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "School_Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_PaperQuestions",
                columns: table => new
                {
                    PaperQuestionId = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Option1 = table.Column<string>(nullable: true),
                    Option2 = table.Column<string>(nullable: true),
                    Option3 = table.Column<string>(nullable: true),
                    Option4 = table.Column<string>(nullable: true),
                    Option5 = table.Column<string>(nullable: true),
                    Option6 = table.Column<string>(nullable: true),
                    PaperId = table.Column<string>(nullable: true),
                    QType = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_PaperQuestions", x => x.PaperQuestionId);
                    table.ForeignKey(
                        name: "FK_School_PaperQuestions_School_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "School_Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_PaperAnswerDetails",
                columns: table => new
                {
                    PaperAnswerId = table.Column<string>(nullable: false),
                    PaperQuestionId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    IsRight = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_PaperAnswerDetails", x => new { x.PaperAnswerId, x.PaperQuestionId });
                    table.ForeignKey(
                        name: "FK_School_PaperAnswerDetails_School_PaperAnswers_PaperAnswerId",
                        column: x => x.PaperAnswerId,
                        principalTable: "School_PaperAnswers",
                        principalColumn: "PaperAnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_PaperAnswerDetails_School_PaperQuestions_PaperQuestionId",
                        column: x => x.PaperQuestionId,
                        principalTable: "School_PaperQuestions",
                        principalColumn: "PaperQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_PaperAnswerDetails_PaperQuestionId",
                table: "School_PaperAnswerDetails",
                column: "PaperQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_School_PaperAnswers_PaperId",
                table: "School_PaperAnswers",
                column: "PaperId");

            migrationBuilder.CreateIndex(
                name: "IX_School_PaperAnswers_StudentId",
                table: "School_PaperAnswers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_School_PaperQuestions_PaperId",
                table: "School_PaperQuestions",
                column: "PaperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_PaperAnswerDetails");

            migrationBuilder.DropTable(
                name: "School_PaperAnswers");

            migrationBuilder.DropTable(
                name: "School_PaperQuestions");

            migrationBuilder.DropTable(
                name: "School_Papers");
        }
    }
}
