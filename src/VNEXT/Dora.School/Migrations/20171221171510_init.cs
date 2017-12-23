using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dora.school.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_BasicData",
                columns: table => new
                {
                    BasicDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_BasicData", x => x.BasicDataId);
                });

            migrationBuilder.CreateTable(
                name: "School_ModuleType",
                columns: table => new
                {
                    ModuleTypeId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_ModuleType", x => x.ModuleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "School_Organization",
                columns: table => new
                {
                    OrganizationId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Organization", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "School_Professional",
                columns: table => new
                {
                    ProfessionalId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Professional", x => x.ProfessionalId);
                });

            migrationBuilder.CreateTable(
                name: "School_PublicClassRoom",
                columns: table => new
                {
                    PublicClassRoomId = table.Column<string>(nullable: false),
                    Area = table.Column<decimal>(nullable: true),
                    BuildingNo = table.Column<string>(maxLength: 256, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    RoomNo = table.Column<string>(maxLength: 256, nullable: false),
                    School = table.Column<string>(maxLength: 256, nullable: false),
                    SeatNum = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_PublicClassRoom", x => x.PublicClassRoomId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    WxAvatar = table.Column<string>(maxLength: 256, nullable: true),
                    WxName = table.Column<string>(maxLength: 256, nullable: true),
                    WxOpenId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingLab",
                columns: table => new
                {
                    TrainingLabId = table.Column<string>(nullable: false),
                    Area = table.Column<decimal>(nullable: true),
                    Base = table.Column<string>(nullable: true),
                    BuildingNo = table.Column<string>(nullable: true),
                    Center = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(nullable: true),
                    LastAction = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RoomNo = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingLab", x => x.TrainingLabId);
                });

            migrationBuilder.CreateTable(
                name: "School_TrainingProject",
                columns: table => new
                {
                    TrainingProjectId = table.Column<string>(nullable: false),
                    Base = table.Column<string>(maxLength: 256, nullable: false),
                    Center = table.Column<string>(maxLength: 256, nullable: false),
                    Content = table.Column<string>(maxLength: 256, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TrainingProject", x => x.TrainingProjectId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "School_Module",
                columns: table => new
                {
                    ModuleId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Ico = table.Column<string>(maxLength: 256, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    ModuleTypeId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Url = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Module", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_School_Module_School_ModuleType_ModuleTypeId",
                        column: x => x.ModuleTypeId,
                        principalTable: "School_ModuleType",
                        principalColumn: "ModuleTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    AppLev = table.Column<string>(maxLength: 256, nullable: false),
                    CouAbs = table.Column<string>(maxLength: 256, nullable: false),
                    CouNat = table.Column<string>(maxLength: 256, nullable: false),
                    CouType = table.Column<string>(maxLength: 256, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Credit = table.Column<decimal>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    OrganizationId = table.Column<string>(nullable: true),
                    Period = table.Column<decimal>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_School_Course_School_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_PersonnelTraining",
                columns: table => new
                {
                    PersonnelTrainingId = table.Column<string>(nullable: false),
                    AudName = table.Column<string>(maxLength: 256, nullable: false),
                    AudOrd = table.Column<int>(nullable: true),
                    AudRes = table.Column<int>(nullable: true),
                    BasReq = table.Column<string>(maxLength: 256, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    CulProPath = table.Column<string>(maxLength: 256, nullable: false),
                    EnrTar = table.Column<string>(maxLength: 256, nullable: false),
                    GraReq = table.Column<string>(maxLength: 256, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    LenOfSch = table.Column<string>(maxLength: 256, nullable: false),
                    MeeSumPath = table.Column<string>(maxLength: 256, nullable: false),
                    OpiExp = table.Column<string>(maxLength: 256, nullable: false),
                    OrganizationId = table.Column<string>(nullable: true),
                    Post = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SubSta = table.Column<int>(nullable: true),
                    SubTime = table.Column<DateTime>(nullable: true),
                    TraObj = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Year = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_PersonnelTraining", x => x.PersonnelTrainingId);
                    table.ForeignKey(
                        name: "FK_School_PersonnelTraining_School_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    JobTit = table.Column<string>(maxLength: 256, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    OrganizationId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Teacher", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_School_Teacher_School_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Teacher_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_TrainingLabDevice",
                columns: table => new
                {
                    TrainingLabDeviceId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TrainingLabId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TrainingLabDevice", x => x.TrainingLabDeviceId);
                    table.ForeignKey(
                        name: "FK_School_TrainingLabDevice_TrainingLab_TrainingLabId",
                        column: x => x.TrainingLabId,
                        principalTable: "TrainingLab",
                        principalColumn: "TrainingLabId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_ApprovalWorkflow",
                columns: table => new
                {
                    ApprovalWorkflowId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(maxLength: 4000, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_ApprovalWorkflow", x => x.ApprovalWorkflowId);
                    table.ForeignKey(
                        name: "FK_School_ApprovalWorkflow_School_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_ApprovalWorkflow_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_Permission",
                columns: table => new
                {
                    PermissionId = table.Column<string>(nullable: false),
                    Authority = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    ModuleId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Permission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_School_Permission_School_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "School_Module",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Permission_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_CourseProfessional",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    ProfessionalId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_CourseProfessional", x => new { x.CourseId, x.ProfessionalId });
                    table.ForeignKey(
                        name: "FK_School_CourseProfessional_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_CourseProfessional_School_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "School_Professional",
                        principalColumn: "ProfessionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_Classes",
                columns: table => new
                {
                    ClassId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    DepID = table.Column<string>(nullable: true),
                    InviteCode = table.Column<string>(maxLength: 256, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    PersonnelTrainingId = table.Column<string>(nullable: true),
                    SpeID = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_School_Classes_School_Organization_DepID",
                        column: x => x.DepID,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Classes_School_PersonnelTraining_PersonnelTrainingId",
                        column: x => x.PersonnelTrainingId,
                        principalTable: "School_PersonnelTraining",
                        principalColumn: "PersonnelTrainingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Classes_School_Organization_SpeID",
                        column: x => x.SpeID,
                        principalTable: "School_Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_PersonnelTrainingApproval",
                columns: table => new
                {
                    PersonnelTrainingApprovalId = table.Column<string>(nullable: false),
                    AudName = table.Column<string>(maxLength: 256, nullable: false),
                    AudOrd = table.Column<int>(nullable: false),
                    AudRes = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(maxLength: 4000, nullable: false),
                    PersonnelTrainingId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_PersonnelTrainingApproval", x => x.PersonnelTrainingApprovalId);
                    table.ForeignKey(
                        name: "FK_School_PersonnelTrainingApproval_School_PersonnelTraining_PersonnelTrainingId",
                        column: x => x.PersonnelTrainingId,
                        principalTable: "School_PersonnelTraining",
                        principalColumn: "PersonnelTrainingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_PersonnelTrainingLog",
                columns: table => new
                {
                    PersonnelTrainingLogId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(maxLength: 4000, nullable: false),
                    PersonnelTrainingId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_PersonnelTrainingLog", x => x.PersonnelTrainingLogId);
                    table.ForeignKey(
                        name: "FK_School_PersonnelTrainingLog_School_PersonnelTraining_PersonnelTrainingId",
                        column: x => x.PersonnelTrainingId,
                        principalTable: "School_PersonnelTraining",
                        principalColumn: "PersonnelTrainingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_CoachRecord",
                columns: table => new
                {
                    CoachRecordId = table.Column<string>(nullable: false),
                    Addr = table.Column<string>(maxLength: 256, nullable: false),
                    Content = table.Column<string>(maxLength: 256, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Date = table.Column<string>(maxLength: 256, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    TeacherId = table.Column<string>(nullable: true),
                    Time = table.Column<string>(maxLength: 256, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_CoachRecord", x => x.CoachRecordId);
                    table.ForeignKey(
                        name: "FK_School_CoachRecord_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingTask",
                columns: table => new
                {
                    TeachingTaskId = table.Column<string>(nullable: false),
                    BegWeek = table.Column<int>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    EndWeek = table.Column<int>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    Term = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingTask", x => x.TeachingTaskId);
                    table.ForeignKey(
                        name: "FK_School_TeachingTask_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TeachingTask_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_CourseClassTeacher",
                columns: table => new
                {
                    ClassId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    TeacherId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_CourseClassTeacher", x => new { x.ClassId, x.CourseId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_School_CourseClassTeacher_School_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_CourseClassTeacher_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_CourseClassTeacher_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    ClassId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_School_Student_School_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Student_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_Syllabus",
                columns: table => new
                {
                    SyllabusId = table.Column<string>(nullable: false),
                    AudName = table.Column<string>(nullable: true),
                    AudOrd = table.Column<int>(nullable: true),
                    AudRes = table.Column<int>(nullable: true),
                    BefCouCode1 = table.Column<string>(nullable: true),
                    BefCouCode2 = table.Column<string>(nullable: true),
                    BefCouCode3 = table.Column<string>(nullable: true),
                    BefCouCode4 = table.Column<string>(nullable: true),
                    BefCouCode5 = table.Column<string>(nullable: true),
                    BefCouName1 = table.Column<string>(nullable: true),
                    BefCouName2 = table.Column<string>(nullable: true),
                    BefCouName3 = table.Column<string>(nullable: true),
                    BefCouName4 = table.Column<string>(nullable: true),
                    BefCouName5 = table.Column<string>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    ConReq = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    EvaWay = table.Column<string>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    MeeSumPath = table.Column<string>(nullable: true),
                    PraCon = table.Column<string>(nullable: true),
                    Pro = table.Column<string>(nullable: true),
                    SubSta = table.Column<int>(nullable: true),
                    SubTime = table.Column<DateTime>(nullable: true),
                    Tar = table.Column<string>(nullable: true),
                    TeaProPath = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UseSta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Syllabus", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_School_Syllabus_School_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Syllabus_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingPlan",
                columns: table => new
                {
                    TeachingPlanId = table.Column<string>(nullable: false),
                    AudName = table.Column<string>(nullable: true),
                    AudOrd = table.Column<int>(nullable: true),
                    AudRes = table.Column<int>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    SubSta = table.Column<int>(nullable: true),
                    SubTime = table.Column<DateTime>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    Term = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UseSta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingPlan", x => x.TeachingPlanId);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlan_School_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlan_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlan_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TrainingPlan",
                columns: table => new
                {
                    TrainingPlanId = table.Column<string>(nullable: false),
                    AudName = table.Column<string>(nullable: true),
                    AudOrd = table.Column<int>(nullable: true),
                    AudRes = table.Column<int>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    SubSta = table.Column<int>(nullable: true),
                    SubTime = table.Column<DateTime>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    Term = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    UseSta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TrainingPlan", x => x.TrainingPlanId);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlan_School_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "School_Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlan_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "School_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlan_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingTaskDetail",
                columns: table => new
                {
                    TeachingTaskDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaRoomCode = table.Column<string>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    Section = table.Column<int>(nullable: true),
                    TeachingTaskId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Week = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingTaskDetail", x => x.TeachingTaskDetailId);
                    table.ForeignKey(
                        name: "FK_School_TeachingTaskDetail_School_TeachingTask_TeachingTaskId",
                        column: x => x.TeachingTaskId,
                        principalTable: "School_TeachingTask",
                        principalColumn: "TeachingTaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_SyllabusApproval",
                columns: table => new
                {
                    SyllabusId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    SyllabusApprovalId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_SyllabusApproval", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_School_SyllabusApproval_School_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "School_Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_SyllabusBook",
                columns: table => new
                {
                    SyllabusId = table.Column<string>(nullable: false),
                    Compiler = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Edition = table.Column<string>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PreTime = table.Column<DateTime>(nullable: false),
                    Press = table.Column<string>(nullable: true),
                    SyllabusBookId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_SyllabusBook", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_School_SyllabusBook_School_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "School_Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_SyllabusLog",
                columns: table => new
                {
                    SyllabusId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    SyllabusLogId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_SyllabusLog", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_School_SyllabusLog_School_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "School_Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_SyllabusPeriod",
                columns: table => new
                {
                    SyllabusId = table.Column<string>(nullable: false),
                    CouCon = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    ExpPer = table.Column<decimal>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    SyllabusPeriodId = table.Column<string>(nullable: true),
                    TeaPer = table.Column<decimal>(nullable: true),
                    UnitOrdNum = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_SyllabusPeriod", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_School_SyllabusPeriod_School_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "School_Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingPlanApproval",
                columns: table => new
                {
                    TeachingPlanApprovalId = table.Column<string>(nullable: false),
                    AudName = table.Column<string>(nullable: true),
                    AudOrd = table.Column<int>(nullable: true),
                    AudRes = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    TeachingPlanId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingPlanApproval", x => x.TeachingPlanApprovalId);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanApproval_School_TeachingPlan_TeachingPlanId",
                        column: x => x.TeachingPlanId,
                        principalTable: "School_TeachingPlan",
                        principalColumn: "TeachingPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingPlanDetail",
                columns: table => new
                {
                    TeachingPlanDetailId = table.Column<string>(nullable: false),
                    Assets = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Job = table.Column<string>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Mode = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Period = table.Column<decimal>(nullable: true),
                    TeaCon = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    TeachingPlanId = table.Column<string>(nullable: true),
                    Test = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingPlanDetail", x => x.TeachingPlanDetailId);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanDetail_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanDetail_School_TeachingPlan_TeachingPlanId",
                        column: x => x.TeachingPlanId,
                        principalTable: "School_TeachingPlan",
                        principalColumn: "TeachingPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TeachingPlanLog",
                columns: table => new
                {
                    TeachingPlanLogId = table.Column<string>(nullable: false),
                    Assets = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Mode = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    PerAdj = table.Column<string>(nullable: true),
                    Period = table.Column<decimal>(nullable: true),
                    PraTra = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    StuNum = table.Column<int>(nullable: true),
                    TeaCon = table.Column<string>(nullable: true),
                    Teacher = table.Column<string>(nullable: true),
                    TeachingPlanId = table.Column<string>(nullable: true),
                    Test = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TeachingPlanLog", x => x.TeachingPlanLogId);
                    table.ForeignKey(
                        name: "FK_School_TeachingPlanLog_School_TeachingPlan_TeachingPlanId",
                        column: x => x.TeachingPlanId,
                        principalTable: "School_TeachingPlan",
                        principalColumn: "TeachingPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TrainingPlanApproval",
                columns: table => new
                {
                    TrainingPlanApprovalId = table.Column<string>(nullable: false),
                    AudName = table.Column<string>(nullable: true),
                    AudOrd = table.Column<int>(nullable: true),
                    AudRes = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true),
                    TrainingPlanId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TrainingPlanApproval", x => x.TrainingPlanApprovalId);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanApproval_School_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "School_TrainingPlan",
                        principalColumn: "TrainingPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TrainingPlanDetail",
                columns: table => new
                {
                    TrainingPlanDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Assets = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Mode = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Period = table.Column<decimal>(nullable: true),
                    TeaCon = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    TrainingLabDeviceId = table.Column<string>(nullable: true),
                    TrainingPlanId = table.Column<string>(nullable: true),
                    TrainingProjectId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TrainingPlanDetail", x => x.TrainingPlanDetailId);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanDetail_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanDetail_School_TrainingLabDevice_TrainingLabDeviceId",
                        column: x => x.TrainingLabDeviceId,
                        principalTable: "School_TrainingLabDevice",
                        principalColumn: "TrainingLabDeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanDetail_School_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "School_TrainingPlan",
                        principalColumn: "TrainingPlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanDetail_School_TrainingProject_TrainingProjectId",
                        column: x => x.TrainingProjectId,
                        principalTable: "School_TrainingProject",
                        principalColumn: "TrainingProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School_TrainingPlanLog",
                columns: table => new
                {
                    TrainingPlanLogId = table.Column<string>(nullable: false),
                    AdjSug = table.Column<string>(nullable: true),
                    Assets = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 64, nullable: false),
                    Date = table.Column<string>(nullable: true),
                    LastAction = table.Column<string>(maxLength: 64, nullable: false),
                    Mode = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Period = table.Column<decimal>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    StuNum = table.Column<int>(nullable: true),
                    TeaCon = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    TrainingLabDeviceId = table.Column<string>(nullable: true),
                    TrainingLabId = table.Column<string>(nullable: true),
                    TrainingPlanId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_TrainingPlanLog", x => x.TrainingPlanLogId);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanLog_School_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "School_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanLog_School_TrainingLabDevice_TrainingLabDeviceId",
                        column: x => x.TrainingLabDeviceId,
                        principalTable: "School_TrainingLabDevice",
                        principalColumn: "TrainingLabDeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanLog_TrainingLab_TrainingLabId",
                        column: x => x.TrainingLabId,
                        principalTable: "TrainingLab",
                        principalColumn: "TrainingLabId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_TrainingPlanLog_School_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "School_TrainingPlan",
                        principalColumn: "TrainingPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_ApprovalWorkflow_OrganizationId",
                table: "School_ApprovalWorkflow",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_School_ApprovalWorkflow_RoleId",
                table: "School_ApprovalWorkflow",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Classes_DepID",
                table: "School_Classes",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_School_Classes_PersonnelTrainingId",
                table: "School_Classes",
                column: "PersonnelTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Classes_SpeID",
                table: "School_Classes",
                column: "SpeID");

            migrationBuilder.CreateIndex(
                name: "IX_School_CoachRecord_TeacherId",
                table: "School_CoachRecord",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Course_OrganizationId",
                table: "School_Course",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseClassTeacher_ClassId",
                table: "School_CourseClassTeacher",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseClassTeacher_CourseId",
                table: "School_CourseClassTeacher",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseClassTeacher_TeacherId",
                table: "School_CourseClassTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseProfessional_CourseId",
                table: "School_CourseProfessional",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseProfessional_ProfessionalId",
                table: "School_CourseProfessional",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Module_ModuleTypeId",
                table: "School_Module",
                column: "ModuleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Permission_ModuleId",
                table: "School_Permission",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Permission_RoleId",
                table: "School_Permission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_School_PersonnelTraining_OrganizationId",
                table: "School_PersonnelTraining",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_School_PersonnelTrainingApproval_PersonnelTrainingId",
                table: "School_PersonnelTrainingApproval",
                column: "PersonnelTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_School_PersonnelTrainingLog_PersonnelTrainingId",
                table: "School_PersonnelTrainingLog",
                column: "PersonnelTrainingId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_Student_ClassId",
                table: "School_Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Student_StudentId",
                table: "School_Student",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_Syllabus_ClassId",
                table: "School_Syllabus",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Syllabus_CourseId",
                table: "School_Syllabus",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusApproval_SyllabusId",
                table: "School_SyllabusApproval",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusBook_SyllabusId",
                table: "School_SyllabusBook",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusLog_SyllabusId",
                table: "School_SyllabusLog",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SyllabusPeriod_SyllabusId",
                table: "School_SyllabusPeriod",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Teacher_OrganizationId",
                table: "School_Teacher",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_School_Teacher_TeacherId",
                table: "School_Teacher",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlan_ClassId",
                table: "School_TeachingPlan",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlan_CourseId",
                table: "School_TeachingPlan",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlan_TeacherId",
                table: "School_TeachingPlan",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlanApproval_TeachingPlanId",
                table: "School_TeachingPlanApproval",
                column: "TeachingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlanDetail_TeacherId",
                table: "School_TeachingPlanDetail",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlanDetail_TeachingPlanId",
                table: "School_TeachingPlanDetail",
                column: "TeachingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingPlanLog_TeachingPlanId",
                table: "School_TeachingPlanLog",
                column: "TeachingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTask_CourseId",
                table: "School_TeachingTask",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTask_TeacherId",
                table: "School_TeachingTask",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TeachingTaskDetail_TeachingTaskId",
                table: "School_TeachingTaskDetail",
                column: "TeachingTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingLabDevice_TrainingLabId",
                table: "School_TrainingLabDevice",
                column: "TrainingLabId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlan_ClassId",
                table: "School_TrainingPlan",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlan_CourseId",
                table: "School_TrainingPlan",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlan_TeacherId",
                table: "School_TrainingPlan",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanApproval_TrainingPlanId",
                table: "School_TrainingPlanApproval",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanDetail_TeacherId",
                table: "School_TrainingPlanDetail",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanDetail_TrainingLabDeviceId",
                table: "School_TrainingPlanDetail",
                column: "TrainingLabDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanDetail_TrainingPlanId",
                table: "School_TrainingPlanDetail",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanDetail_TrainingProjectId",
                table: "School_TrainingPlanDetail",
                column: "TrainingProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanLog_TeacherId",
                table: "School_TrainingPlanLog",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanLog_TrainingLabDeviceId",
                table: "School_TrainingPlanLog",
                column: "TrainingLabDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanLog_TrainingLabId",
                table: "School_TrainingPlanLog",
                column: "TrainingLabId");

            migrationBuilder.CreateIndex(
                name: "IX_School_TrainingPlanLog_TrainingPlanId",
                table: "School_TrainingPlanLog",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_ApprovalWorkflow");

            migrationBuilder.DropTable(
                name: "School_BasicData");

            migrationBuilder.DropTable(
                name: "School_CoachRecord");

            migrationBuilder.DropTable(
                name: "School_CourseClassTeacher");

            migrationBuilder.DropTable(
                name: "School_CourseProfessional");

            migrationBuilder.DropTable(
                name: "School_Permission");

            migrationBuilder.DropTable(
                name: "School_PersonnelTrainingApproval");

            migrationBuilder.DropTable(
                name: "School_PersonnelTrainingLog");

            migrationBuilder.DropTable(
                name: "School_PublicClassRoom");

            migrationBuilder.DropTable(
                name: "School_Student");

            migrationBuilder.DropTable(
                name: "School_SyllabusApproval");

            migrationBuilder.DropTable(
                name: "School_SyllabusBook");

            migrationBuilder.DropTable(
                name: "School_SyllabusLog");

            migrationBuilder.DropTable(
                name: "School_SyllabusPeriod");

            migrationBuilder.DropTable(
                name: "School_TeachingPlanApproval");

            migrationBuilder.DropTable(
                name: "School_TeachingPlanDetail");

            migrationBuilder.DropTable(
                name: "School_TeachingPlanLog");

            migrationBuilder.DropTable(
                name: "School_TeachingTaskDetail");

            migrationBuilder.DropTable(
                name: "School_TrainingPlanApproval");

            migrationBuilder.DropTable(
                name: "School_TrainingPlanDetail");

            migrationBuilder.DropTable(
                name: "School_TrainingPlanLog");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "School_Professional");

            migrationBuilder.DropTable(
                name: "School_Module");

            migrationBuilder.DropTable(
                name: "School_Syllabus");

            migrationBuilder.DropTable(
                name: "School_TeachingPlan");

            migrationBuilder.DropTable(
                name: "School_TeachingTask");

            migrationBuilder.DropTable(
                name: "School_TrainingProject");

            migrationBuilder.DropTable(
                name: "School_TrainingLabDevice");

            migrationBuilder.DropTable(
                name: "School_TrainingPlan");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "School_ModuleType");

            migrationBuilder.DropTable(
                name: "TrainingLab");

            migrationBuilder.DropTable(
                name: "School_Classes");

            migrationBuilder.DropTable(
                name: "School_Course");

            migrationBuilder.DropTable(
                name: "School_Teacher");

            migrationBuilder.DropTable(
                name: "School_PersonnelTraining");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "School_Organization");
        }
    }
}
