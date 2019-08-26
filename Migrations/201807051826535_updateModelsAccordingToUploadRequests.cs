namespace LMXRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelsAccordingToUploadRequests : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Requests", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "Surname", c => c.String());
            AlterColumn("dbo.Requests", "Name", c => c.String());
        }
    }
}
