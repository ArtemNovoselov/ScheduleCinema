using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ScheduleCinema.DAL.EF;
using ScheduleCinema.DAL.Interfaces;
using ScheduleCinema.Models;
using Movie = ScheduleCinema.Models.Interfaces.Movie;

namespace ScheduleCinema.DAL.Repositories
{
    public class MoviesRepository : IGenericRepository<Movie>
    {
        private readonly ScheduleCinemaDbContext _dbContext;

        public MoviesRepository(ScheduleCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie Get(int movieId)
        {
            return _dbContext.Movies.Find(movieId);
        }

        public IEnumerable<Movie> FindBy(Expression<Func<Movie, bool>> expression)
        {
            return _dbContext.Set<Movie>().Where(expression).ToList();
        }

        public void Create(Movie movie)
        {
            _dbContext.Movies.Add(movie);
        }

        public void Edit(Movie movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
        }

        public void Delete(Movie movie)
        {
            _dbContext.Movies.Remove(movie);
        }
    }
}