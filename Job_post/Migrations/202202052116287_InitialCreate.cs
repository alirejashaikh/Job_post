namespace Job_post.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_JobData",
                c => new
                    {
                        Job_Id = c.Int(nullable: false, identity: true),
                        Job_Title = c.String(maxLength: 40),
                        No_Of_Openings = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        Job_Location = c.String(maxLength: 40),
                        Job_Description = c.String(maxLength: 200),
                        Job_Timing = c.String(),
                        Interview_Details = c.String(maxLength: 40),
                        Company_Name = c.String(maxLength: 40),
                        Contact_Person_Name = c.String(maxLength: 40),
                        Phone_Number = c.Int(nullable: false),
                        Email = c.String(maxLength: 40),
                        Job_Address = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Job_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_JobData");
        }
    }
}
