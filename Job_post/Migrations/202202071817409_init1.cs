namespace Job_post.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginDatas", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginDatas", "Email");
        }
    }
}
