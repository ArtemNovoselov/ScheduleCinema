using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ScheduleCinema.DAL.EF;
using ScheduleCinema.DAL.Interfaces;
using ScheduleCinema.Models;

namespace ScheduleCinema.DAL.Repositories
{
    public class CinemaSessionsRepository : IGenericRepository<CinemaSession>
    {
        private readonly ScheduleCinemaDbContext _dbContext;

        public CinemaSessionsRepository(ScheduleCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CinemaSession> GetCinemasSessions(DateTime date)
        {
            if (_dbContext.CinemaSessions.Any(cinemaSession => cinemaSession.CinemaSessionDate == date))
            {
                return
                    _dbContext.CinemaSessions.Include(cinemaSession => cinemaSession.Cinema)
                        .Include(cinemaSession => cinemaSession.CinemaSessionSpecs)
                        .Include(cinemaSession => cinemaSession.Movie)
                        .Where(cinemaSession => cinemaSession.CinemaSessionDate == date);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<CinemaSession> GetAll()
        {
            return _dbContext.CinemaSessions.ToList();
        }

        public CinemaSession Get(int cinemaSessionId)
        {
            return _dbContext.CinemaSessions.Find(cinemaSessionId);
        }

        public IEnumerable<CinemaSession> FindBy(Expression<Func<CinemaSession, bool>> expression)
        {
            return _dbContext.Set<CinemaSession>().Where(expression).ToList();
        }

        public void Create(CinemaSession cinemaSession)
        {
            _dbContext.CinemaSessions.Add(cinemaSession);
        }

        public void Edit(CinemaSession cinemaSession)
        {
            _dbContext.Entry(cinemaSession).State = EntityState.Modified;
        }

        public void Delete(CinemaSession cinemaSession)
        {
            _dbContext.CinemaSessions.Remove(cinemaSession);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}