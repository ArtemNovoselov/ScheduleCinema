using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;
using ScheduleCinema.Repositories.Interfaces;

namespace ScheduleCinema.Repositories
{
    public class SheduleCinemaSqlRepository : ISheduleCinemaRepository
    {
        private readonly ScheduleCinemaDbContext _dbContext;

        public SheduleCinemaSqlRepository(ScheduleCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<Cinema> GetCinemas()
        {
            return _dbContext.Cinemas.Include(cinema => cinema.Schedules).Include(cinema => cinema.CinemaSessions).ToList();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.Include(movie => movie.CinemaSessions).ToList();
        }

        public IEnumerable<CinemaSchedule> GetSchedules(DateTime date)
        {
            if (_dbContext.Schedules.Any(schedule => schedule.ScheduleDate == date))
            {
                return _dbContext.Schedules.Include(schedule => schedule.Cinema).Where(schedule => schedule.ScheduleDate == date);
            }
            else
            {
                return null;
            }
        }

        public CinemaSchedule GetSchedule(int? scheduleId)
        {
            return _dbContext.Schedules.Find(scheduleId);
        }

        public void SaveSchedule(CinemaSchedule cinemaSchedule)
        {
            _dbContext.Schedules.Add(cinemaSchedule);
            _dbContext.SaveChanges();
        }

        public void EditSchedule(CinemaSchedule cinemaSchedule)
        {

            _dbContext.Entry(cinemaSchedule).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteSchedule(int scheduleId)
        {
            var schedule = _dbContext.Schedules.Find(scheduleId);
            schedule.CinemaSessions.Clear();
            _dbContext.Schedules.Remove(schedule);
        }
    }
}