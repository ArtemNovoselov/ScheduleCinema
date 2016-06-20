namespace ScheduleCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleIdToCinemaScheduleId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CinemaSession", name: "CinemaSchedule_CinemaScheduleId", newName: "CinemaScheduleId");
            RenameIndex(table: "dbo.CinemaSession", name: "IX_CinemaSchedule_CinemaScheduleId", newName: "IX_CinemaScheduleId");
            AlterColumn("dbo.CinemaSchedule", "ScheduleDescription", c => c.String(maxLength: 500, unicode: false));
            DropColumn("dbo.CinemaSession", "ScheduleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CinemaSession", "ScheduleId", c => c.Int(nullable: false));
            AlterColumn("dbo.CinemaSchedule", "ScheduleDescription", c => c.String(nullable: false, maxLength: 500, unicode: false));
            RenameIndex(table: "dbo.CinemaSession", name: "IX_CinemaScheduleId", newName: "IX_CinemaSchedule_CinemaScheduleId");
            RenameColumn(table: "dbo.CinemaSession", name: "CinemaScheduleId", newName: "CinemaSchedule_CinemaScheduleId");
        }
    }
}
