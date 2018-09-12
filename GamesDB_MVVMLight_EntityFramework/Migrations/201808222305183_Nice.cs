namespace GamesDB_MVVMLight_EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {

        }
    }
}
