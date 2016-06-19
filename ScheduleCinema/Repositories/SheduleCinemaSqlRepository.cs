using System;
using System.Collections.Generic;
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
            return _dbContext.Cinemas.ToList();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public IEnumerable<Schedule> GetSchedules(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Schedule GetSchedule(int scheduleId)
        {
            throw new NotImplementedException();
        }

        public void SaveSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void EditSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void DeleteSchedule(int scheduleId)
        {
            throw new NotImplementedException();
        }
    }
}