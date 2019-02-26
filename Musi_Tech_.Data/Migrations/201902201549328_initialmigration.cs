namespace Musi_Tech_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LessonRequest",
                c => new
                    {
                        LessonRequestID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        CustomerFullName = c.String(nullable: false),
                        Instrument = c.String(nullable: false),
                        RequestedStartDate = c.DateTime(nullable: false),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LessonRequestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LessonRequest");
        }
    }
}
