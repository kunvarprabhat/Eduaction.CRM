using Eduaction.DataModel.DataModels;
using Eduaction.DataModel.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Eduaction.DataModel
{
    public partial class EducationDbContext : DbContext
    {
        private readonly string conString = ConfigSetting.SqlConnection;
        public EducationDbContext()
        {
        }
        public EducationDbContext(string _conString)
        {
            conString = _conString;
        }
        public EducationDbContext(DbContextOptions<EducationDbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }


        #region On Configuring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conString);
            }
        }
        #endregion


        #region Entity Map
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CallTrackerInfoMap(modelBuilder.Entity<CallTracker>());
            new CastCategoryInfoMap(modelBuilder.Entity<CastCategory>());
            new CityMasterInfoMap(modelBuilder.Entity<CityMaster>());
            new CollageLeadProcessInfoMap(modelBuilder.Entity<CollageLeadProcess>());
            new CollegeCategoryInfoMap(modelBuilder.Entity<CollegeCategory>());
            new CollegeCourseInfoMap(modelBuilder.Entity<CollegeCourse>());
            new CollegeMasterInfoMap(modelBuilder.Entity<CollegeMaster>());
            new CollegeStatusInfoMap(modelBuilder.Entity<CollegeStatus>());
            new CourseMasterInfoMap(modelBuilder.Entity<CourseMaster>());
            new EmployeeMasterInfoMap(modelBuilder.Entity<EmployeeMaster>());
            new EntranceMasterInfoMap(modelBuilder.Entity<EntranceMaster>());
            new EntrancePercentileInfoMap(modelBuilder.Entity<EntrancePercentile>());
            new FinanceMasterInfoMap(modelBuilder.Entity<FinanceMaster>());
            new FollowUpInfoMap(modelBuilder.Entity<FollowUp>());
            new GenderMasterInfoMap(modelBuilder.Entity<GenderMaster>());
            new LoginInfoInfoMap(modelBuilder.Entity<LoginInfo>());
            new PreferredCollegeInfoMap(modelBuilder.Entity<PreferredCollege>());
            new PreferredLocationInfoMap(modelBuilder.Entity<PreferredLocation>());
            new RefreshTokenInfoMap(modelBuilder.Entity<RefreshToken>());
            new RemarksMasterInfoMap(modelBuilder.Entity<RemarksMaster>());
            new RoleInfoMap(modelBuilder.Entity<Role>());
            new SmtpdetailInfoMap(modelBuilder.Entity<Smtpdetail>());
            new SourceMasterInfoMap(modelBuilder.Entity<SourceMaster>());
            new StateMasterInfoMap(modelBuilder.Entity<StateMaster>());
            new StudentEntryModuleInfoMap(modelBuilder.Entity<StudentEntryModule>());
            new ThirdPartyMasterInfoMap(modelBuilder.Entity<ThirdPartyMaster>());


        }
        #endregion
        #region Entity Sets
        public virtual DbSet<CallTracker> CallTrackers { get; set; }
        public virtual DbSet<CastCategory> CastCategories { get; set; }
        public virtual DbSet<CityMaster> CityMasters { get; set; }
        public virtual DbSet<CollageLeadProcess> CollageLeadProcesses { get; set; }
        public virtual DbSet<CollegeCategory> CollegeCategories { get; set; }
        public virtual DbSet<CollegeCourse> CollegeCourses { get; set; }
        public virtual DbSet<CollegeMaster> CollegeMasters { get; set; }
        public virtual DbSet<CollegeStatus> CollegeStatuses { get; set; }
        public virtual DbSet<CourseMaster> CourseMasters { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }
        public virtual DbSet<EntranceMaster> EntranceMasters { get; set; }
        public virtual DbSet<EntrancePercentile> EntrancePercentiles { get; set; }
        public virtual DbSet<FinanceMaster> FinanceMasters { get; set; }
        public virtual DbSet<FollowUp> FollowUps { get; set; }
        public virtual DbSet<GenderMaster> GenderMasters { get; set; }
        public virtual DbSet<LoginInfo> LoginInfos { get; set; }
        public virtual DbSet<PreferredCollege> PreferredColleges { get; set; }
        public virtual DbSet<PreferredLocation> PreferredLocations { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<RemarksMaster> RemarksMasters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Smtpdetail> Smtpdetails { get; set; }
        public virtual DbSet<SourceMaster> SourceMasters { get; set; }
        public virtual DbSet<StateMaster> StateMasters { get; set; }
        public virtual DbSet<StudentEntryModule> StudentEntryModules { get; set; }
        public virtual DbSet<ThirdPartyMaster> ThirdPartyMasters { get; set; }
        #endregion
    }
}