namespace ScheduleCinema.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ScheduleCinemaDbContext : DbContext
    {
        public ScheduleCinemaDbContext()
            : base("name=ScheduleCinemaDbContext")
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<CinemaSession> CinemaSessions { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<CinemaSchedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>()
                .Property(e => e.CinemaAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Cinema>()
                .Property(e => e.CinemaName)
                .IsUnicode(false);

            modelBuilder.Entity<Cinema>()
                .HasMany(e => e.CinemaSessions)
                .WithRequired(e => e.Cinema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cinema>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Cinema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CinemaSession>()
                .Property(e => e.CinemaSessionPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Movie>()
                .Property(e => e.MovieName)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.MovieDirector)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.CinemaSessions)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CinemaSchedule>()
                .Property(e => e.ScheduleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CinemaSchedule>()
                .HasMany(e => e.CinemaSessions)
                .WithRequired(e => e.CinemaSchedule)
                .WillCascadeOnDelete(false);
        }
    }
}
