namespace LMXRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPriceToVehicleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "PricePerDay", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "PricePerDay");
        }
    }
}
