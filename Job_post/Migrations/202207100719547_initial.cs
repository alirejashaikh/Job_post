namespace Job_post.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyQueries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Message = c.String(),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Pincode = c.Int(nullable: false),
                        ContactPerson = c.String(),
                        Detail = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.LoginDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        username = c.String(),
                        password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Location = c.String(),
                        Qualification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserQueries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Message = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserQueries");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.LoginDatas");
            DropTable("dbo.tbl_JobData");
            DropTable("dbo.CompanyRegistrations");
            DropTable("dbo.CompanyQueries");
            DropTable("dbo.AdminLogins");
        }
    }
}
