namespace BikeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        BikeId = c.Int(nullable: false, identity: true),
                        BikeName = c.String(nullable: false),
                        BikePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BikeTypeId = c.Int(nullable: false),
                        RentStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BikeId);
            
            CreateTable(
                "dbo.BikeTypes",
                c => new
                    {
                        BikeTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BikeTypeId);
            
            CreateTable(
                "dbo.RentStates",
                c => new
                    {
                        RentStateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RentStateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RentStates");
            DropTable("dbo.BikeTypes");
            DropTable("dbo.Bikes");
        }
    }
}
