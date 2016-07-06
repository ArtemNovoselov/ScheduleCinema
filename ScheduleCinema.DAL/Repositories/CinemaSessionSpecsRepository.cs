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
    public class CinemaSessionSpecsRepository : IGenericRepository<CinemaSessionSpec>
    {
        private readonly ScheduleCinemaDbContext _dbContext;

        public CinemaSessionSpecsRepository(ScheduleCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

        public void Create(CinemaSessionSpec cinemaSessionSpec)
        {
            _dbContext.CinemaSessionSpecs.Add(cinemaSessionSpec);
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