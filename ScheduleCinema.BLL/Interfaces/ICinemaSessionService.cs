using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.Models;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.BLL.Interfaces
{
    public interface ICinemaSessionService //Service! Not repository!
    {
        IEnumerable<ICinema> GetCinemas();
        IEnumerable<IMovie> GetMovies();
        void AddSessionSpecs(IEnumerable<ICinemaSessionSpec> cinemaSessionSpecs);
        void RemoveSessionSpecs(int cinemaSessionId);
        IEnumerable<ICinemaSession> GetCinemasSessions(DateTime date);
        ICinemaSession GetCinemaSession(int cinemaSessionId);
        void AddCinemaSession(ICinemaSession cinemaSession);
        void RemoveCinemaSession(ICinemaSession cinemaSession);
        void EditCinemaSession(ICinemaSession cinemaSession);
        void Dispose();
    }
}
