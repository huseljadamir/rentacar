namespace LMXRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelsAccordingToUploadRequests1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Requests", new[] { "VehicleId" });
            AlterColumn("dbo.Requests", "VehicleId", c => c.Int());
            CreateIndex("dbo.Requests", "VehicleId");
            AddForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Requests", new[] { "VehicleId" });
            AlterColumn("dbo.Requests", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "VehicleId");
            AddForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
    }
}
