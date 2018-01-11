using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dora.school.Migrations
{
    public partial class init20180405 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TrainingProject");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TrainingPlanLog");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TrainingPlanDetail");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TrainingPlanApproval");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TrainingPlan");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TrainingLabDevice");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TrainingLab");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TeachingTaskDetail");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TeachingTask");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TeachingPlanLog");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TeachingPlanDetail");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TeachingPlanApproval");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_TeachingPlan");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Teacher");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_SyllabusPeriod");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_SyllabusLog");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_SyllabusBook");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_SyllabusApproval");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Syllabus");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Student");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_PublicClassRoom");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Professional");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_PersonnelTrainingLog");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_PersonnelTrainingApproval");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_PersonnelTraining");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Permission");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Organization");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_ModuleType");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Module");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_CourseProfessional");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_CourseClassTeacher");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Course");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_CoachRecord");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_Classes");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_BasicData");

            migrationBuilder.DropColumn(
                name: "LastAction",
                table: "School_ApprovalWorkflow");

            migrationBuilder.AddColumn<string>(
                name: "Term",
                table: "School_CourseClassTeacher",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Term",
                table: "School_CourseClassTeacher");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TrainingProject",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TrainingPlanLog",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TrainingPlanDetail",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TrainingPlanApproval",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TrainingPlan",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TrainingLabDevice",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TrainingLab",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TeachingTaskDetail",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TeachingTask",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TeachingPlanLog",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TeachingPlanDetail",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TeachingPlanApproval",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_TeachingPlan",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Teacher",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_SyllabusPeriod",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_SyllabusLog",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_SyllabusBook",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_SyllabusApproval",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Syllabus",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Student",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_PublicClassRoom",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Professional",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_PersonnelTrainingLog",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_PersonnelTrainingApproval",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_PersonnelTraining",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Permission",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Organization",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_ModuleType",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Module",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_CourseProfessional",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_CourseClassTeacher",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Course",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_CoachRecord",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_Classes",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_BasicData",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastAction",
                table: "School_ApprovalWorkflow",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
