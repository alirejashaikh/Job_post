using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Job_post.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("JobDataDB")
        {

        }
        public DbSet<Job_Data> job_Datas { get; set; }
        public DbSet<LoginData> loginDatas { get; set; }
        public DbSet<CompanyRegistration> CompanyRegistrations { get; set; }
        public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserQuery> UserQueries { get; set; }
        public DbSet<CompanyQuery> companyQueries { get; set; }
    }
}