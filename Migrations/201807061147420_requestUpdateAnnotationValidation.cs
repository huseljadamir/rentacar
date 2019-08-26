namespace LMXRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requestUpdateAnnotationValidation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Requests", new[] { "VehicleId" });
            AlterColumn("dbo.Requests", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Requests", "VehicleId", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "Car");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "Car", c => c.String());
            AlterColumn("dbo.Requests", "VehicleId", c => c.Int());
            AlterColumn("dbo.Requests", "Email", c => c.String());
            CreateIndex("dbo.Requests", "VehicleId");
            AddForeignKey("dbo.Requests", "VehicleId", "dbo.Vehicles", "Id");
        }
    }
}
