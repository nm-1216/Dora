

namespace Dora.Database
{
    using Domain.Entities.School;
    using Dora.Domain.Entities.Application;
    using Microsoft.EntityFrameworkCore;

    public partial class DoraContext
    {
        //#region Application
        //public DbSet<EventLog> EventLogs { get; set; }
        //public DbSet<LoginLog> LoginLogs { get; set; }
        //public DbSet<Action> Actions { get; set; }
        //public DbSet<Application> Applications { get; set; }
        public DbSet<Group> Groups { get; set; }
        //public DbSet<Dict> Dicts { get; set; }

        //#endregion

        #region System
        //public DbSet<Class> Classes { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<SchoolUser> SchoolUsers { get; set; }
        //public DbSet<SchoolUserInClass> SchoolUserInClass { get; set; }

        #endregion


        #region School

        #region Auth
        public DbSet<Permission> Permissions { get; set; }
        #endregion

        #region BasicData
        public DbSet<Class> Classes { get; set; }
        public DbSet<ApprovalWorkflow> ApprovalWorkflows { get; set; }
        public DbSet<BasicData> BasicDatas { get; set; }
        public DbSet<CoachRecord> CoachRecords { get; set; }
        public DbSet<Course1> Courses { get; set; }
        public DbSet<CourseProfessional> CourseProfessionals { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<PublicClassRoom> PublicClassRooms { get; set; }
        public DbSet<TrainingLabDevice> TrainingLabDevices { get; set; }
        public DbSet<TrainingProject> TrainingProjects { get; set; }
        public DbSet<Infomation> Infomations { get; set; }
        public DbSet<Term> Terms { get; set; }


        #endregion

        #region Model
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleType> ModuleTypes { get; set; }
        #endregion

        #region Organization
        public DbSet<Organization> Organizations { get; set; }
        #endregion

        #region PersonnelTraining
        public DbSet<PersonnelTraining> PersonnelTrainings { get; set; }
        public DbSet<PersonnelTrainingApproval> PersonnelTrainingApprovals { get; set; }
        public DbSet<PersonnelTrainingLog> PersonnelTrainingLogs { get; set; }
        #endregion

        #region SchoolUser
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        #endregion

        #region Syllabus
        public DbSet<Syllabus> Syllabuss { get; set; }
        public DbSet<SyllabusApproval> SyllabusApprovals { get; set; }
        public DbSet<SyllabusBook> SyllabusBooks { get; set; }
        public DbSet<SyllabusLog> SyllabusLog { get; set; }
        public DbSet<SyllabusPeriod> SyllabusPeriod { get; set; }
        public DbSet<SyllabusFirstCourse> SyllabusFirstCourse { get; set; }
        public DbSet<SyllabusProfessional> SyllabusProfessionals { get; set; }
        public DbSet<SyllabusTeacher> SyllabusTeachers { get; set; }

        #endregion

        #region TeachingPlan
        public DbSet<TeachingPlan> TeachingPlans { get; set; }
        public DbSet<TeachingPlanLog> TeachingPlanLogs { get; set; }
        public DbSet<TeachingPlanApproval> TeachingPlanApprovals { get; set; }
        public DbSet<TeachingPlanDetail> TeachingPlanDetails { get; set; }
        public DbSet<TeachingPlanClass> TeachingPlanClasses { get; set; }
        public DbSet<TeachingPlanTeacher> TeachingPlanTeachers { get; set; }

        #endregion


        #region TeachingPlan
        public DbSet<TeachingTask> TeachingTasks { get; set; }
        public DbSet<TeachingTaskDetail> TeachingTaskDetails { get; set; }
        public DbSet<TeachingTaskClass> TeachingTaskClasses { get; set; }
        public DbSet<TeachingTaskTeacher> TeachingTaskTeachers { get; set; }


        #endregion


        #region TrainingPlan
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<TrainingPlanApproval> TrainingPlanApprovals { get; set; }
        public DbSet<TrainingPlanDetail> TrainingPlanDetails { get; set; }
        public DbSet<TrainingPlanLog> TrainingPlanLogs { get; set; }

        #endregion

        #region Papers
        public DbSet<PaperAnswerDetails> PaperAnswerDetails { get; set; }
        public DbSet<PaperAnswers> PaperAnswers { get; set; }
        public DbSet<PaperQuestions> PaperQuestions { get; set; }
        public DbSet<Papers> Papers { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Courseware> Courseware { get; set; }
        
        #endregion
        
        #endregion
    }
}
