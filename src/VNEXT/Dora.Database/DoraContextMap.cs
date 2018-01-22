

namespace Dora.Database
{
    using Domain.Mapping.School;
    using Dora.Domain.Mapping.Application;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;

    public partial class DoraContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region 权限管理

            //builder.AddConfiguration(new EventLogMap());
            //builder.AddConfiguration(new LoginLogMap());

            builder.AddConfiguration(new GroupMap());
            //builder.AddConfiguration(new UserInGroupMap());

            //builder.AddConfiguration(new ActionMap());
            //builder.AddConfiguration(new ActionInRoleMap());

            //builder.AddConfiguration(new ApplicationMap());

            ////builder.AddConfiguration(new ApplicationUserMap());
            //builder.AddConfiguration(new DictMap());




            #endregion


            //builder.AddConfiguration(new ClassMap());
            //builder.AddConfiguration(new GradeMap());
            //builder.AddConfiguration(new SchoolUserInClassMap());
            //builder.AddConfiguration(new SchoolUserMap());
            //builder.AddConfiguration(new CourseMap());


            #region School
            #region Auth
            builder.AddConfiguration(new PermissionMap());
            #endregion

            #region BasicData
            builder.AddConfiguration(new ClassMap());
            builder.AddConfiguration(new ApprovalWorkflowMap());
            builder.AddConfiguration(new BasicDataMap());
            builder.AddConfiguration(new CoachRecordMap());
            builder.AddConfiguration(new CourseMap());
            //builder.AddConfiguration(new CourseClassTeacherMap());
            builder.AddConfiguration(new CourseProfessionalMap());
            builder.AddConfiguration(new ProfessionalMap());
            builder.AddConfiguration(new PublicClassRoomMap());
            builder.AddConfiguration(new InfomationMap());
            builder.AddConfiguration(new TermMap());


            builder.AddConfiguration(new TrainingLabMap());
            builder.AddConfiguration(new TrainingLabDeviceMap());
            builder.AddConfiguration(new TrainingProjectMap());


            #endregion

            #region Model
            builder.AddConfiguration(new ModuleMap());
            builder.AddConfiguration(new ModuleTypeMap());
            #endregion


            #region Organization
            builder.AddConfiguration(new OrganizationMap());

            #endregion
            #region PersonnelTraining
            builder.AddConfiguration(new PersonnelTrainingMap());
            builder.AddConfiguration(new PersonnelTrainingApprovalMap());
            builder.AddConfiguration(new PersonnelTrainingLogMap());

            #endregion
            #region SchoolUser
            builder.AddConfiguration(new TeacherMap());
            builder.AddConfiguration(new StudentMap());

            #endregion

            #region Syllabus
            builder.AddConfiguration(new SyllabusMap());
            builder.AddConfiguration(new SyllabusApprovalMap());
            builder.AddConfiguration(new SyllabusBookMap());
            builder.AddConfiguration(new SyllabusLogMap());
            builder.AddConfiguration(new SyllabusPeriodMap());
            builder.AddConfiguration(new SyllabusFirstCourseMap());

            #endregion
            #region TeachingPlan
            builder.AddConfiguration(new TeachingPlanMap());
            builder.AddConfiguration(new TeachingPlanLogMap());
            builder.AddConfiguration(new TeachingPlanApprovalMap());
            builder.AddConfiguration(new TeachingPlanDetailMap());

            #endregion

            #region TeachingPlan
            builder.AddConfiguration(new TeachingTaskMap());
            builder.AddConfiguration(new TeachingTaskDetailMap());
            builder.AddConfiguration(new TeachingTaskClassMap());
            builder.AddConfiguration(new TeachingTaskTeacherMap());


            #endregion
            #region TrainingPlan
            builder.AddConfiguration(new TrainingPlanMap());
            builder.AddConfiguration(new TrainingPlanApprovalMap());
            builder.AddConfiguration(new TrainingPlanDetailMap());
            builder.AddConfiguration(new TrainingPlanLogMap());
            #endregion


            #endregion

        }
    }
}
