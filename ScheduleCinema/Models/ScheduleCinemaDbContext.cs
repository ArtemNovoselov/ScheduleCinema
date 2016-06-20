namespace ScheduleCinema.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ScheduleCinemaDbContext : DbContext
    {
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<CinemaMovie> CinemaMovies { get; set; }
        public virtual DbSet<City> Cities { get; set; }
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
                .HasMany(e => e.CinemaMovies)
                .WithRequired(e => e.Cinema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Cinemas)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.MovieName)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.CinemaMovies)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);
        }
    }
}
