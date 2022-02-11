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
    }
}