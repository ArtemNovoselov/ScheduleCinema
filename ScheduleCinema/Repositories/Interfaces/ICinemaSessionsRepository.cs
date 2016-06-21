using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.Repositories.Interfaces
{
    public interface ICinemaSessionsRepository : IGenericRepository<CinemaSession>
    {
        IEnumerable<Cinema> GetCinemas();
        IEnumerable<Movie> GetMovies();
        IEnumerable<CinemaSession> GetCinemasSessions(DateTime date);
        CinemaSession GetCinemaSession(int cinemaSessionId);
    }
}