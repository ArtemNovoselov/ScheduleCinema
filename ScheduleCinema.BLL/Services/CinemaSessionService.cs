using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.BLL.Interfaces;
using ScheduleCinema.DAL.Interfaces;
using ScheduleCinema.Models;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.BLL.Services
{
    public class CinemaSessionService : ICinemaSessionService
    {
        private IUnitOfWork Database { get; set; }

        public CinemaSessionService(IUnitOfWork unit)
        {
            Database = unit;
        }
        public IEnumerable<ICinema> GetCinemas()
        {
            return Database.Cinemas.GetAll();
        }

        public IEnumerable<IMovie> GetMovies()
        {
            return Database.Movies.GetAll();
        }

        public void AddSessionSpecs(IEnumerable<ICinemaSessionSpec> cinemaSessionSpecs)
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

        public void AddCinemaSession(ICinemaSession cinemaSession)
        {
            Database.CinemaSessions.Create(cinemaSession);
            Database.Save();
        }

        public void RemoveCinemaSession(ICinemaSession cinemaSession)
        {
            Database.CinemaSessions.Delete(cinemaSession);
            Database.Save();
        }

        public void EditCinemaSession(ICinemaSession cinemaSession)
        {
            Database.CinemaSessions.Edit(cinemaSession);
            Database.Save();
        }

        public IEnumerable<ICinemaSession> GetCinemasSessions(DateTime date)
        {
            return Database.CinemaSessions.FindBy(cinemaSession => cinemaSession.CinemaSessionDate == date);
        }

        public ICinemaSession GetCinemaSession(int cinemaSessionId)
        {
            return Database.CinemaSessions.Get(cinemaSessionId);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
