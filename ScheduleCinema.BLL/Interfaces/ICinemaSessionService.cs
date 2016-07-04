using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.Models;

namespace ScheduleCinema.BLL.Interfaces
{
    interface ICinemaSessionService //Service! Not repository!
    {
        IEnumerable<Cinema> GetCinemas();
        IEnumerable<Movie> GetMovies();
        void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs, int cinemaSessionId);
        void RemoveSessionSpecs(int cinemaSessionId);
        IEnumerable<CinemaSession> GetCinemasSessions(DateTime date);
        CinemaSession GetCinemaSession(int cinemaSessionId);
        void Dispose();
    }
}
