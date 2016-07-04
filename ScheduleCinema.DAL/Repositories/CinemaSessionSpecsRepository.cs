using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ScheduleCinema.DAL.EF;
using ScheduleCinema.DAL.Interfaces;
using ScheduleCinema.DAL.Models;

namespace ScheduleCinema.DAL.Repositories
{
    public class CinemaSessionSpecsRepository : IGenericRepository<CinemaSessionSpec>
    {
        private readonly ScheduleCinemaDbContext _dbContext;

        public CinemaSessionSpecsRepository(ScheduleCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*public void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs, int cinemaSessionId)
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

        public IEnumerable<CinemaSessionSpec> GetCinemasSessions(DateTime date)
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
        }*/

        public IEnumerable<CinemaSessionSpec> GetAll()
        {
            return _dbContext.CinemaSessionSpecs.ToList();
        }

        public CinemaSessionSpec Get(int cinemaSessionSpecId)
        {
            return _dbContext.CinemaSessionSpecs.Find(cinemaSessionSpecId);
        }

        public IEnumerable<CinemaSessionSpec> FindBy(Expression<Func<CinemaSessionSpec, bool>> expression)
        {
            return _dbContext.Set<CinemaSessionSpec>().Where(expression).ToList();
        }

        public int Create(CinemaSessionSpec cinemaSessionSpec)
        {
            _dbContext.CinemaSessionSpecs.Add(cinemaSessionSpec);
            return cinemaSessionSpec.CinemaSessionSpecId;
        }

        public void Edit(CinemaSessionSpec cinemaSessionSpec)
        {
            _dbContext.Entry(cinemaSessionSpec).State = EntityState.Modified;
        }

        public void Delete(CinemaSessionSpec cinemaSessionSpec)
        {
            _dbContext.CinemaSessionSpecs.Remove(cinemaSessionSpec);
        }
    }
}