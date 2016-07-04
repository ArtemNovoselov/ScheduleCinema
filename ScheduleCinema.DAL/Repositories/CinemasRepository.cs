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
    public class CinemasRepository : IGenericRepository<Cinema>
    {
        private readonly ScheduleCinemaDbContext _dbContext;

        public CinemasRepository(ScheduleCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cinema> GetAll()
        {
            return _dbContext.Cinemas.ToList();
        }

        public Cinema Get(int cinemaId)
        {
            return _dbContext.Cinemas.Find(cinemaId);
        }

        public IEnumerable<Cinema> FindBy(Expression<Func<Cinema, bool>> expression)
        {
            return _dbContext.Set<Cinema>().Where(expression).ToList();
        }

        public int Create(Cinema cinema)
        {
            _dbContext.Cinemas.Add(cinema);
            return cinema.CinemaId;
        }

        public void Edit(Cinema cinema)
        {
            _dbContext.Entry(cinema).State = EntityState.Modified;
        }

        public void Delete(Cinema cinema)
        {
            _dbContext.Cinemas.Remove(cinema);
        }
    }
}