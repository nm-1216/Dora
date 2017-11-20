using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dora.Test;

namespace Dora.Test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171116152655_up20171116")]
    partial class up20171116
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dora.Domain.Entities.School.Class", b =>
                {
                    b.Property<string>("ClassId")
                        .HasColumnName("ClassId");

                    b.Property<string>("CourseId")
                        .HasColumnName("CourseId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("InviteCode")
                        .IsRequired()
                        .HasColumnName("InviteCode")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("ClassId");

                    b.HasIndex("CourseId");

                    b.ToTable("School_Class");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnName("CourseId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("CourseId");

                    b.ToTable("School_Course");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Grade", b =>
                {
                    b.Property<string>("GradeId")
                        .HasColumnName("GradeId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("GradeId");

                    b.ToTable("School_Grade");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SchoolUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("UserId");

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

                    b.Property<int>("UserType")
                        .HasColumnName("UserType")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("WxAvatar")
                        .HasColumnName("WxAvatar")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("WxName")
                        .HasColumnName("WxName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("WxOpenId")
                        .HasColumnName("WxOpenId")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("UserId");

                    b.ToTable("School_User");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SchoolUserInClass", b =>
                {
                    b.Property<string>("ClassId")
                        .HasColumnName("ClassId");

                    b.Property<string>("UserId")
                        .HasColumnName("UserId");

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

                    b.HasKey("ClassId", "UserId");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("School_UserInClass");
                });

            modelBuilder.Entity("Dora.Domain.Entities.System.Dict", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnName("Key");

                    b.Property<string>("Type")
                        .HasColumnName("Type");

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

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("Value")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Key", "Type");

                    b.ToTable("System_Dicts");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.Class", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Dora.Domain.Entities.School.SchoolUserInClass", b =>
                {
                    b.HasOne("Dora.Domain.Entities.School.Class", "Class")
                        .WithMany("User")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dora.Domain.Entities.School.SchoolUser", "User")
                        .WithMany("Classes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
