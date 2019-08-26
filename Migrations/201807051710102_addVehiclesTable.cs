namespace LMXRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVehiclesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        NrOfSeats = c.Int(nullable: false),
                        Color = c.String(),
                        YearOfProduction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
