using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.Models;
using Cinema = ScheduleCinema.Models.DBMS.MongoDB.Cinema;
using CinemaSession = ScheduleCinema.Models.Interfaces.CinemaSession;
using CinemaSessionSpec = ScheduleCinema.Models.Interfaces.CinemaSessionSpec;
using Movie = ScheduleCinema.Models.Interfaces.Movie;

namespace ScheduleCinema.BLL.Interfaces
{
    public interface ICinemaSessionService //Service! Not repository!
    {
        IEnumerable<Cinema> GetCinemas();
        IEnumerable<Movie> GetMovies();
        void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs);
        void RemoveSessionSpecs(int cinemaSessionId);
        IEnumerable<CinemaSession> GetCinemasSessions(DateTime date);
        CinemaSession GetCinemaSession(int cinemaSessionId);
        void AddCinemaSession(CinemaSession cinemaSession);
        void RemoveCinemaSession(CinemaSession cinemaSession);
        void EditCinemaSession(CinemaSession cinemaSession);
        void Dispose();
    }
}
