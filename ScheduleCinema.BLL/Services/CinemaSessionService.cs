using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.BLL.Interfaces;
using ScheduleCinema.DAL.Interfaces;
using ScheduleCinema.Models;

namespace ScheduleCinema.BLL.Services
{
    public class CinemaSessionService : ICinemaSessionService
    {
        private IUnitOfWork Database { get; set; }

        public CinemaSessionService(IUnitOfWork unit)
        {
            Database = unit;
        }
        public IEnumerable<Cinema> GetCinemas()
        {
            return Database.Cinemas.GetAll();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return Database.Movies.GetAll();
        }

        public void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs)
        {
            foreach (var cinemaSessionSpec in cinemaSessionSpecs)
            {
                Database.CinemaSessionSpecs.Create(cinemaSessionSpec);
            }
            Database.Save();
        }

        public void RemoveSessionSpecs(int cinemaSessionId)
        {
            var originalSession = Database.CinemaSessions.Get(cinemaSessionId);
            foreach (var cinemaSessionSpec in originalSession.CinemaSessionSpecs)
            {
                Database.CinemaSessionSpecs.Delete(cinemaSessionSpec);
            }
            Database.Save();
        }

        public void AddCinemaSession(CinemaSession cinemaSession)
        {
            Database.CinemaSessions.Create(cinemaSession);
            Database.Save();
        }

        public void RemoveCinemaSession(CinemaSession cinemaSession)
        {
            Database.CinemaSessions.Delete(cinemaSession);
            Database.Save();
        }

        public void EditCinemaSession(CinemaSession cinemaSession)
        {
            Database.CinemaSessions.Edit(cinemaSession);
            Database.Save();
        }

        public IEnumerable<CinemaSession> GetCinemasSessions(DateTime date)
        {
            return Database.CinemaSessions.FindBy(cinemaSession => cinemaSession.CinemaSessionDate == date);
        }

        public CinemaSession GetCinemaSession(int cinemaSessionId)
        {
            return Database.CinemaSessions.Get(cinemaSessionId);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
