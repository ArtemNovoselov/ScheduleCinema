namespace ScheduleCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchedulaNameAndMovieDuration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        CinemaId = c.Int(nullable: false),
                        CinemaAddress = c.String(nullable: false, maxLength: 200, unicode: false),
                        CinemaName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CinemaId);
            
            CreateTable(
                "dbo.CinemaSession",
                c => new
                    {
                        CinemaSessionId = c.Int(nullable: false),
                        CinemaId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        CinemaSessionTime = c.Time(nullable: false, precision: 7),
                        ScheduleId = c.Int(nullable: false),
                        CinemaSessionPrice = c.Decimal(nullable: false, storeType: "money"),
                        CinemaSchedule_CinemaScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CinemaSessionId)
                .ForeignKey("dbo.CinemaSchedule", t => t.CinemaSchedule_CinemaScheduleId)
                .ForeignKey("dbo.Movie", t => t.MovieId)
                .ForeignKey("dbo.Cinema", t => t.CinemaId)
                .Index(t => t.CinemaId)
                .Index(t => t.MovieId)
                .Index(t => t.CinemaSchedule_CinemaScheduleId);
            
            CreateTable(
                "dbo.CinemaSchedule",
                c => new
                    {
                        CinemaScheduleId = c.Int(nullable: false),
                        CinemaId = c.Int(nullable: false),
                        ScheduleDate = c.DateTime(nullable: false, storeType: "date"),
                        ScheduleDescription = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.CinemaScheduleId)
                .ForeignKey("dbo.Cinema", t => t.CinemaId)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        MovieName = c.String(nullable: false, maxLength: 200, unicode: false),
                        MovieDirector = c.String(nullable: false, maxLength: 100, unicode: false),
                        MovieDuration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CinemaSchedule", "CinemaId", "dbo.Cinema");
            DropForeignKey("dbo.CinemaSession", "CinemaId", "dbo.Cinema");
            DropForeignKey("dbo.CinemaSession", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.CinemaSession", "CinemaSchedule_CinemaScheduleId", "dbo.CinemaSchedule");
            DropIndex("dbo.CinemaSchedule", new[] { "CinemaId" });
            DropIndex("dbo.CinemaSession", new[] { "CinemaSchedule_CinemaScheduleId" });
            DropIndex("dbo.CinemaSession", new[] { "MovieId" });
            DropIndex("dbo.CinemaSession", new[] { "CinemaId" });
            DropTable("dbo.Movie");
            DropTable("dbo.CinemaSchedule");
            DropTable("dbo.CinemaSession");
            DropTable("dbo.Cinema");
        }
    }
}
