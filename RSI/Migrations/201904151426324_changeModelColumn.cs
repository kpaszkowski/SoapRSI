namespace RSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModelColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cows", "DateOfCalving", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cows", "DateOfFertilization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cows", "DateOfFertilization", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cows", "DateOfCalving");
        }
    }
}
