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
    }
}