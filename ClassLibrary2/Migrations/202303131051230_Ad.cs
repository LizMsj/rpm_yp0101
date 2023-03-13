namespace ClassLibrary2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Scp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "Scp");
        }
    }
}
