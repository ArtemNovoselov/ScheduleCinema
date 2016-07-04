using System;
using System.Collections.Generic;
using ScheduleCinema.DAL.Models;

namespace ScheduleCinema.DAL.Interfaces
{
    public interface ICinemaSessionsRepository : IGenericRepository<CinemaSession>
    {
        IEnumerable<Cinema> GetCinemas();
        IEnumerable<Movie> GetMovies();
        void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs, int cinemaSessionId);
        void RemoveSessionSpecs(int cinemaSessionId);
        IEnumerable<CinemaSession> GetCinemasSessions(DateTime date);
        CinemaSession GetCinemaSession(int cinemaSessionId);
    }
}