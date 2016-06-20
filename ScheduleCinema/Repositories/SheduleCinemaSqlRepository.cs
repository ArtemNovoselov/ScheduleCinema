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
            return _dbContext.Cinemas.Include(cinema => cinema.CinemaSessions).ToList();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.Include(movie => movie.CinemaSessions).ToList();
        }
        public IEnumerable<CinemaSession> GetCinemsSessions(DateTime date)
        {
            if (_dbContext.CinemaSessions.Any(cinemaSession => cinemaSession.CinemaSessionDate == date))
            {
                return _dbContext.CinemaSessions.Include(cinemaSession => cinemaSession.Cinema).Where(cinemaSession => cinemaSession.CinemaSessionDate == date);
            }
            else
            {
                return null;
            }
        }

        public CinemaSession GetCinemaSession(int cinemaSessionId)
        {
            return _dbContext.CinemaSessions.Find(cinemaSessionId);
        }

        public void SaveSchedule(CinemaSession cinemaSession)
        {
            _dbContext.CinemaSessions.Add(cinemaSession);
            _dbContext.SaveChanges();
        }

        public void EditSchedule(CinemaSession cinemaSession)
        {

            _dbContext.Entry(cinemaSession).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteSchedule(int cinemaSessionId)
        {
            var cinemaSession = _dbContext.CinemaSessions.Find(cinemaSessionId);
            cinemaSession.CinemaSessionSpecs.Clear();
            _dbContext.CinemaSessions.Remove(cinemaSession);
        }
    }
}