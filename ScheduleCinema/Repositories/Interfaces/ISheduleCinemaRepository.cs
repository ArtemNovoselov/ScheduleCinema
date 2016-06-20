using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.Repositories.Interfaces
{
    public interface ISheduleCinemaRepository
    {
        IEnumerable<Cinema> GetCinemas();
        IEnumerable<Movie> GetMovies();
        IEnumerable<CinemaSession> GetCinemsSessions(DateTime date);
        CinemaSession GetCinemaSession(int cinemaSessionId);
        void SaveCinemaSession(CinemaSession cinemaSession);
        void EditCinemaSession(CinemaSession cinemaSession);
        void DeleteCinemaSession(int cinemaSessionId);
    }
}