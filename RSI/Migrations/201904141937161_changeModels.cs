namespace RSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CowBreed = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfFertilization = c.DateTime(nullable: false),
                        TagNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Events");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Week = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Cows");
        }
    }
}
