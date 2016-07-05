using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.Models;

namespace ScheduleCinema.BLL.Interfaces
{
    public interface ICinemaSessionService //Service! Not repository!
    {
        IEnumerable<Cinema> GetCinemas();
        IEnumerable<Movie> GetMovies();
        void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs, int cinemaSessionId);
        void RemoveSessionSpecs(int cinemaSessionId);
        IEnumerable<CinemaSession> GetCinemasSessions(DateTime date);
        CinemaSession GetCinemaSession(int cinemaSessionId);
        int AddCinemaSession(CinemaSession cinemaSession);
        void RemoveCinemaSession(CinemaSession cinemaSession);
        void EditCinemaSession(CinemaSession cinemaSession);
        void Dispose();
    }
}
