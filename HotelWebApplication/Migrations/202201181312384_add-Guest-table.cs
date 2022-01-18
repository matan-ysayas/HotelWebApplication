namespace HotelWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGuesttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        yaerOfBirth = c.DateTime(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Guests");
        }
    }
}
