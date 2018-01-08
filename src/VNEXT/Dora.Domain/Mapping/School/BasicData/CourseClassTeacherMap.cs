//namespace Dora.Domain.Mapping.School
//{
//    using Dora.Infrastructure.Features.Common;
//    using Entities.School;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    public class CourseClassTeacherMap : EntityBaseConfiguration<CourseClassTeacher>
//    {
//        public override void ConfigureDerived(EntityTypeBuilder<CourseClassTeacher> builder)
//        {
//            ///Primary Key
//            builder.HasKey(b => new { b.ClassId, b.CourseId, b.TeacherId });

//            ///Properties


//            ///Table & Column Mappings
//            builder.ToTable("School_CourseClassTeacher");

//            ///Relationships
//            builder.HasOne(b => b.Class).WithMany(b => b.CourseClassTeachers).HasForeignKey(b => b.ClassId);
//            builder.HasOne(b => b.Course).WithMany(b => b.CourseClassTeachers).HasForeignKey(b => b.CourseId);
//            builder.HasOne(b => b.Teacher).WithMany(b => b.CourseClassTeachers).HasForeignKey(b => b.TeacherId);
//        }
//    }
//}
