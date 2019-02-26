namespace Musi_Tech_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        SongTitle = c.String(nullable: false),
                        Artist = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SongID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Playlist");
        }
    }
}
