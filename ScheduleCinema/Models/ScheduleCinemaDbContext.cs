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
        public virtual DbSet<CinemaSessionSpec> CinemaSessionSpecs { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

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

            modelBuilder.Entity<CinemaSession>()
                .HasMany(e => e.CinemaSessionSpecs)
                .WithRequired(e => e.CinemaSession)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CinemaSessionSpec>()
                .Property(e => e.CinemaSessionSpecPrice)
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
        }
    }
}
