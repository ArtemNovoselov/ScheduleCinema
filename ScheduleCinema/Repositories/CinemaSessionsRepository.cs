using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ScheduleCinema.Models;
using ScheduleCinema.Repositories.Interfaces;

namespace ScheduleCinema.Repositories
{
    public class CinemaSessionsRepository : ICinemaSessionsRepository
    {
        private readonly ScheduleCinemaDbContext _dbContext;

        public CinemaSessionsRepository(ScheduleCinemaDbContext dbContext)
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

        public void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs, int cinemaSessionId)
        {
            foreach (var cinemaSessionSpec in cinemaSessionSpecs.Where(
                        cinemaSessionSpec =>
                            !_dbContext.CinemaSessionSpecs.Any(
                                spec =>
                                    spec.CinemaSessionId == cinemaSessionSpec.CinemaSessionId &&
                                    spec.CinemaSessionSpecTime == cinemaSessionSpec.CinemaSessionSpecTime)))
            {
                _dbContext.CinemaSessionSpecs.Add(cinemaSessionSpec);
            }
        }

        public void RemoveSessionSpecs(int cinemaSessionId)
        {
            var originalSession = _dbContext.CinemaSessions.Find(cinemaSessionId);
            _dbContext.CinemaSessionSpecs.RemoveRange(originalSession.CinemaSessionSpecs);
        }

        public IEnumerable<CinemaSession> GetCinemasSessions(DateTime date)
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

        public IEnumerable<CinemaSession> GetAll()
        {
            return _dbContext.CinemaSessions.ToList();
        }

        public IEnumerable<CinemaSession> FindBy(Expression<Func<CinemaSession, bool>> expression)
        {
            return _dbContext.Set<CinemaSession>().Where(expression).ToList();
        }

        public int Create(CinemaSession cinemaSession)
        {
            _dbContext.CinemaSessions.Add(cinemaSession);
            return cinemaSession.CinemaSessionId;
        }

        public void Edit(CinemaSession cinemaSession)
        {
            _dbContext.Entry(cinemaSession).State = EntityState.Modified;
        }

        public void Delete(CinemaSession cinemaSession)
        {
            cinemaSession.CinemaSessionSpecs.Clear();
            _dbContext.CinemaSessions.Remove(cinemaSession);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}