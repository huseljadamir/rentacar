namespace LMXRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVehiclesTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "VehicleId");
            AddForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Requests", new[] { "VehicleId" });
            DropColumn("dbo.Requests", "VehicleId");
        }
    }
}
