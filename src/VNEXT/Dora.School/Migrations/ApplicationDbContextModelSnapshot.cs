using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dora.School;

namespace dora.school.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dora.Domain.Entities.School.ApprovalWorkflow", b =>
                {
                    b.Property<string>("ApprovalWorkflowId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Order");

                    b.Property<string>("OrganizationId");

                    b.Property<string>("RoleId");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("ApprovalWorkflowId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("RoleId");

                    b.ToTable("School_ApprovalWorkflow");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.BasicData", b =>
                {
                    b.Property<int>("BasicDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Order");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("BasicDataId");

                    b.ToTable("School_BasicData");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Class", b =>
                {
                    b.Property<string>("ClassId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("DepID");

                    b.Property<string>("InviteCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PersonnelTrainingId");

                    b.Property<string>("SpeID");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("ClassId");

                    b.HasIndex("DepID");

                    b.HasIndex("PersonnelTrainingId");

                    b.HasIndex("SpeID");

                    b.ToTable("School_Classes");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.CoachRecord", b =>
                {
                    b.Property<string>("CoachRecordId");

                    b.Property<string>("Addr")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("TeacherId");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("CoachRecordId");

                    b.HasIndex("TeacherId");

                    b.ToTable("School_CoachRecord");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Course", b =>
                {
                    b.Property<string>("CourseId");

                    b.Property<string>("AppLev")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("CouAbs")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("CouNat")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("CouType")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<decimal?>("Credit");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("OrganizationId");

                    b.Property<decimal?>("Period");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("CourseId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("School_Course");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.CourseClassTeacher", b =>
                {
                    b.Property<string>("ClassId");

                    b.Property<string>("CourseId");

                    b.Property<string>("TeacherId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("ClassId", "CourseId", "TeacherId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("School_CourseClassTeacher");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.CourseProfessional", b =>
                {
                    b.Property<string>("CourseId");

                    b.Property<string>("ProfessionalId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("CourseId", "ProfessionalId");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProfessionalId");

                    b.ToTable("School_CourseProfessional");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Module", b =>
                {
                    b.Property<string>("ModuleId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Ico")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("ModuleTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("ModuleId");

                    b.HasIndex("ModuleTypeId");

                    b.ToTable("School_Module");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.ModuleType", b =>
                {
                    b.Property<string>("ModuleTypeId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("ModuleTypeId");

                    b.ToTable("School_ModuleType");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Organization", b =>
                {
                    b.Property<string>("OrganizationId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("OrganizationId");

                    b.ToTable("School_Organization");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Permission", b =>
                {
                    b.Property<string>("PermissionId");

                    b.Property<int>("Authority");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("ModuleId");

                    b.Property<string>("RoleId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("PermissionId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("RoleId");

                    b.ToTable("School_Permission");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.PersonnelTraining", b =>
                {
                    b.Property<string>("PersonnelTrainingId");

                    b.Property<string>("AudName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int?>("AudOrd");

                    b.Property<int?>("AudRes");

                    b.Property<string>("BasReq")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("CulProPath")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("EnrTar")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("GraReq")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LenOfSch")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("MeeSumPath")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("OpiExp")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("OrganizationId");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Status");

                    b.Property<int?>("SubSta");

                    b.Property<DateTime?>("SubTime");

                    b.Property<string>("TraObj")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("PersonnelTrainingId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("School_PersonnelTraining");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.PersonnelTrainingApproval", b =>
                {
                    b.Property<string>("PersonnelTrainingApprovalId");

                    b.Property<string>("AudName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("AudOrd");

                    b.Property<int>("AudRes");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("PersonnelTrainingId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("PersonnelTrainingApprovalId");

                    b.HasIndex("PersonnelTrainingId");

                    b.ToTable("School_PersonnelTrainingApproval");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.PersonnelTrainingLog", b =>
                {
                    b.Property<string>("PersonnelTrainingLogId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("PersonnelTrainingId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("PersonnelTrainingLogId");

                    b.HasIndex("PersonnelTrainingId");

                    b.ToTable("School_PersonnelTrainingLog");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Professional", b =>
                {
                    b.Property<string>("ProfessionalId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("ProfessionalId");

                    b.ToTable("School_Professional");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.PublicClassRoom", b =>
                {
                    b.Property<string>("PublicClassRoomId");

                    b.Property<decimal?>("Area");

                    b.Property<string>("BuildingNo")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("RoomNo")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("School")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int?>("SeatNum");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("PublicClassRoomId");

                    b.ToTable("School_PublicClassRoom");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SchoolUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("UserType");

                    b.Property<string>("WxAvatar")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("WxName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("WxOpenId")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Student", b =>
                {
                    b.Property<string>("StudentId");

                    b.Property<string>("ClassId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("School_Student");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Syllabus", b =>
                {
                    b.Property<string>("SyllabusId");

                    b.Property<string>("AudName");

                    b.Property<int?>("AudOrd");

                    b.Property<int?>("AudRes");

                    b.Property<string>("BefCouCode1");

                    b.Property<string>("BefCouCode2");

                    b.Property<string>("BefCouCode3");

                    b.Property<string>("BefCouCode4");

                    b.Property<string>("BefCouCode5");

                    b.Property<string>("BefCouName1");

                    b.Property<string>("BefCouName2");

                    b.Property<string>("BefCouName3");

                    b.Property<string>("BefCouName4");

                    b.Property<string>("BefCouName5");

                    b.Property<string>("ClassId");

                    b.Property<string>("ConReq");

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("EvaWay");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("MeeSumPath");

                    b.Property<string>("PraCon");

                    b.Property<string>("Pro");

                    b.Property<int?>("SubSta");

                    b.Property<DateTime?>("SubTime");

                    b.Property<string>("Tar");

                    b.Property<string>("TeaProPath");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("UseSta");

                    b.HasKey("SyllabusId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.ToTable("School_Syllabus");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusApproval", b =>
                {
                    b.Property<string>("SyllabusId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo");

                    b.Property<string>("SyllabusApprovalId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("SyllabusId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("School_SyllabusApproval");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusBook", b =>
                {
                    b.Property<string>("SyllabusId");

                    b.Property<string>("Compiler");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Edition");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name");

                    b.Property<DateTime>("PreTime");

                    b.Property<string>("Press");

                    b.Property<string>("SyllabusBookId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("SyllabusId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("School_SyllabusBook");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusLog", b =>
                {
                    b.Property<string>("SyllabusId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo");

                    b.Property<string>("SyllabusLogId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("SyllabusId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("School_SyllabusLog");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusPeriod", b =>
                {
                    b.Property<string>("SyllabusId");

                    b.Property<string>("CouCon");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<decimal?>("ExpPer");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("SyllabusPeriodId");

                    b.Property<decimal?>("TeaPer");

                    b.Property<int?>("UnitOrdNum");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("SyllabusId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("School_SyllabusPeriod");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Teacher", b =>
                {
                    b.Property<string>("TeacherId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("JobTit")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("OrganizationId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TeacherId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("School_Teacher");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlan", b =>
                {
                    b.Property<string>("TeachingPlanId");

                    b.Property<string>("AudName");

                    b.Property<int?>("AudOrd");

                    b.Property<int?>("AudRes");

                    b.Property<string>("ClassId");

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("SubSta");

                    b.Property<DateTime?>("SubTime");

                    b.Property<string>("TeacherId");

                    b.Property<string>("Term");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("UseSta");

                    b.HasKey("TeachingPlanId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("School_TeachingPlan");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlanApproval", b =>
                {
                    b.Property<string>("TeachingPlanApprovalId");

                    b.Property<string>("AudName");

                    b.Property<int?>("AudOrd");

                    b.Property<int?>("AudRes");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo");

                    b.Property<string>("TeachingPlanId");

                    b.Property<DateTime>("Time");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("User");

                    b.HasKey("TeachingPlanApprovalId");

                    b.HasIndex("TeachingPlanId");

                    b.ToTable("School_TeachingPlanApproval");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlanDetail", b =>
                {
                    b.Property<string>("TeachingPlanDetailId");

                    b.Property<string>("Assets");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Job");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Mode");

                    b.Property<int?>("Order");

                    b.Property<decimal?>("Period");

                    b.Property<string>("TeaCon");

                    b.Property<string>("TeacherId");

                    b.Property<string>("TeachingPlanId");

                    b.Property<int>("Test");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TeachingPlanDetailId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TeachingPlanId");

                    b.ToTable("School_TeachingPlanDetail");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlanLog", b =>
                {
                    b.Property<string>("TeachingPlanLogId");

                    b.Property<string>("Assets");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Date");

                    b.Property<string>("Job");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Mode");

                    b.Property<int?>("Order");

                    b.Property<string>("PerAdj");

                    b.Property<decimal?>("Period");

                    b.Property<string>("PraTra");

                    b.Property<string>("Section");

                    b.Property<int?>("StuNum");

                    b.Property<string>("TeaCon");

                    b.Property<string>("Teacher");

                    b.Property<string>("TeachingPlanId");

                    b.Property<string>("Test");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TeachingPlanLogId");

                    b.HasIndex("TeachingPlanId");

                    b.ToTable("School_TeachingPlanLog");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingTask", b =>
                {
                    b.Property<string>("TeachingTaskId");

                    b.Property<int?>("BegWeek");

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("EndWeek");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo");

                    b.Property<string>("TeacherId");

                    b.Property<string>("Term");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TeachingTaskId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("School_TeachingTask");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingTaskDetail", b =>
                {
                    b.Property<long>("TeachingTaskDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaRoomCode");

                    b.Property<string>("ClassId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo");

                    b.Property<int?>("Section");

                    b.Property<string>("TeachingTaskId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Week");

                    b.HasKey("TeachingTaskDetailId");

                    b.HasIndex("TeachingTaskId");

                    b.ToTable("School_TeachingTaskDetail");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingLab", b =>
                {
                    b.Property<string>("TrainingLabId");

                    b.Property<decimal?>("Area");

                    b.Property<string>("Base");

                    b.Property<string>("BuildingNo");

                    b.Property<string>("Center");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("LastAction");

                    b.Property<string>("Name");

                    b.Property<string>("RoomNo");

                    b.Property<string>("School");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser");

                    b.HasKey("TrainingLabId");

                    b.ToTable("TrainingLab");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingLabDevice", b =>
                {
                    b.Property<string>("TrainingLabDeviceId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Status");

                    b.Property<string>("TrainingLabId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<decimal?>("Value");

                    b.HasKey("TrainingLabDeviceId");

                    b.HasIndex("TrainingLabId");

                    b.ToTable("School_TrainingLabDevice");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlan", b =>
                {
                    b.Property<string>("TrainingPlanId");

                    b.Property<string>("AudName");

                    b.Property<int?>("AudOrd");

                    b.Property<int?>("AudRes");

                    b.Property<string>("ClassId");

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("SubSta");

                    b.Property<DateTime?>("SubTime");

                    b.Property<string>("TeacherId");

                    b.Property<string>("Term");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("UseSta");

                    b.HasKey("TrainingPlanId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("School_TrainingPlan");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlanApproval", b =>
                {
                    b.Property<string>("TrainingPlanApprovalId");

                    b.Property<string>("AudName");

                    b.Property<int?>("AudOrd");

                    b.Property<int?>("AudRes");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Memo");

                    b.Property<DateTime?>("Time");

                    b.Property<string>("TrainingPlanId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("User");

                    b.HasKey("TrainingPlanApprovalId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("School_TrainingPlanApproval");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlanDetail", b =>
                {
                    b.Property<long>("TrainingPlanDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Assets");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Mode");

                    b.Property<int?>("Order");

                    b.Property<decimal?>("Period");

                    b.Property<string>("TeaCon");

                    b.Property<string>("TeacherId");

                    b.Property<string>("TrainingLabDeviceId");

                    b.Property<string>("TrainingPlanId");

                    b.Property<string>("TrainingProjectId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TrainingPlanDetailId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TrainingLabDeviceId");

                    b.HasIndex("TrainingPlanId");

                    b.HasIndex("TrainingProjectId");

                    b.ToTable("School_TrainingPlanDetail");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlanLog", b =>
                {
                    b.Property<string>("TrainingPlanLogId");

                    b.Property<string>("AdjSug");

                    b.Property<string>("Assets");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Date");

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Mode");

                    b.Property<int?>("Order");

                    b.Property<decimal?>("Period");

                    b.Property<string>("Section");

                    b.Property<int?>("StuNum");

                    b.Property<string>("TeaCon");

                    b.Property<string>("TeacherId");

                    b.Property<string>("TrainingLabDeviceId");

                    b.Property<string>("TrainingLabId");

                    b.Property<string>("TrainingPlanId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TrainingPlanLogId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TrainingLabDeviceId");

                    b.HasIndex("TrainingLabId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("School_TrainingPlanLog");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingProject", b =>
                {
                    b.Property<string>("TrainingProjectId");

                    b.Property<string>("Base")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TrainingProjectId");

                    b.ToTable("School_TrainingProject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.ApprovalWorkflow", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Organization", "Department")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Class", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Organization", "Department")
                        .WithMany()
                        .HasForeignKey("DepID");

                    b.HasOne("Dora.Domain.Entities.School.PersonnelTraining", "PersonnelTraining")
                        .WithMany()
                        .HasForeignKey("PersonnelTrainingId");

                    b.HasOne("Dora.Domain.Entities.School.Organization", "Professional")
                        .WithMany()
                        .HasForeignKey("SpeID");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.CoachRecord", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Course", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Organization", "Department")
                        .WithMany()
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.CourseClassTeacher", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Class", "Class")
                        .WithMany("CourseClassTeachers")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dora.Domain.Entities.School.Course", "Course")
                        .WithMany("CourseClassTeachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany("CourseClassTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.CourseProfessional", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Course", "Course")
                        .WithMany("CourseProfessionals")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dora.Domain.Entities.School.Professional", "Professional")
                        .WithMany("CourseProfessionals")
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Module", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.ModuleType", "ModuleType")
                        .WithMany("Modules")
                        .HasForeignKey("ModuleTypeId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Permission", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Module", "Module")
                        .WithMany("Permissions")
                        .HasForeignKey("ModuleId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.PersonnelTraining", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Organization", "Professional")
                        .WithMany()
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.PersonnelTrainingApproval", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.PersonnelTraining", "PersonnelTraining")
                        .WithMany("PersonnelTrainingApprovals")
                        .HasForeignKey("PersonnelTrainingId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.PersonnelTrainingLog", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.PersonnelTraining", "PersonnelTraining")
                        .WithMany("PersonnelTrainingLogs")
                        .HasForeignKey("PersonnelTrainingId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Student", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.HasOne("Dora.Domain.Entities.School.SchoolUser", "SchoolUser")
                        .WithOne("Student")
                        .HasForeignKey("Dora.Domain.Entities.School.Student", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Syllabus", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Class")
                        .WithMany("Syllabus")
                        .HasForeignKey("ClassId");

                    b.HasOne("Dora.Domain.Entities.School.Course", "Course")
                        .WithMany("Syllabuss")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusApproval", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Syllabus", "Syllabus")
                        .WithMany("SyllabusApprovals")
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusBook", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Syllabus", "Syllabus")
                        .WithMany("SyllabusBooks")
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusLog", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Syllabus", "Syllabus")
                        .WithMany("SyllabusLogs")
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SyllabusPeriod", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Syllabus", "Syllabus")
                        .WithMany("SyllabusPeriods")
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Teacher", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Organization", "Department")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Dora.Domain.Entities.School.SchoolUser", "SchoolUser")
                        .WithOne("Teacher")
                        .HasForeignKey("Dora.Domain.Entities.School.Teacher", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlan", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Dora.Domain.Entities.School.Course", "Course")
                        .WithMany("TeachingPlans")
                        .HasForeignKey("CourseId");

                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlanApproval", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.TeachingPlan", "TeachingPlan")
                        .WithMany("TeachingPlanApprovals")
                        .HasForeignKey("TeachingPlanId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlanDetail", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("Dora.Domain.Entities.School.TeachingPlan", "TeachingPlan")
                        .WithMany("TeachingPlanDetails")
                        .HasForeignKey("TeachingPlanId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingPlanLog", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.TeachingPlan", "TeachingPlan")
                        .WithMany("TeachingPlanLogs")
                        .HasForeignKey("TeachingPlanId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingTask", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TeachingTaskDetail", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.TeachingTask", "TeachingTask")
                        .WithMany("TeachingTaskDetails")
                        .HasForeignKey("TeachingTaskId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingLabDevice", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.TrainingLab", "TrainingLab")
                        .WithMany("TrainingLabDevice")
                        .HasForeignKey("TrainingLabId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlan", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Dora.Domain.Entities.School.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlanApproval", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.TrainingPlan", "TrainingPlan")
                        .WithMany("TrainingPlanApprovals")
                        .HasForeignKey("TrainingPlanId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlanDetail", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("Dora.Domain.Entities.School.TrainingLabDevice", "TrainingLabDevice")
                        .WithMany()
                        .HasForeignKey("TrainingLabDeviceId");

                    b.HasOne("Dora.Domain.Entities.School.TrainingPlan", "TrainingPlan")
                        .WithMany("TrainingPlanDetails")
                        .HasForeignKey("TrainingPlanId");

                    b.HasOne("Dora.Domain.Entities.School.TrainingProject", "TrainingProject")
                        .WithMany()
                        .HasForeignKey("TrainingProjectId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.TrainingPlanLog", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("Dora.Domain.Entities.School.TrainingLabDevice", "TrainingLabDevice")
                        .WithMany()
                        .HasForeignKey("TrainingLabDeviceId");

                    b.HasOne("Dora.Domain.Entities.School.TrainingLab", "TrainingLab")
                        .WithMany()
                        .HasForeignKey("TrainingLabId");

                    b.HasOne("Dora.Domain.Entities.School.TrainingPlan", "TrainingPlan")
                        .WithMany("TrainingPlanLogs")
                        .HasForeignKey("TrainingPlanId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.SchoolUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.SchoolUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dora.Domain.Entities.School.SchoolUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
