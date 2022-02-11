namespace Job_post.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginDatas", "FullName", c => c.String());
            AddColumn("dbo.LoginDatas", "Date_Of_Birth", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoginDatas", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginDatas", "Address");
            DropColumn("dbo.LoginDatas", "Date_Of_Birth");
            DropColumn("dbo.LoginDatas", "FullName");
        }
    }
}
