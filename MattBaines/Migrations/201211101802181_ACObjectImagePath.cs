namespace MattBaines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ACObjectImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvertisingCreativeObjects", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdvertisingCreativeObjects", "ImagePath");
        }
    }
}
