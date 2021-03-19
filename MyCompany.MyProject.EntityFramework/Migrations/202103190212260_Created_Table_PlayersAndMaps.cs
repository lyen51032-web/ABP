namespace MyCompany.MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Created_Table_PlayersAndMaps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MapName = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PlayerName = c.String(),
                        MapID = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.MapID, cascadeDelete: true)
                .Index(t => t.MapID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "MapID", "dbo.Maps");
            DropIndex("dbo.Players", new[] { "MapID" });
            DropTable("dbo.Players");
            DropTable("dbo.Maps");
        }
    }
}
