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
    class CinemaSessionService : ICinemaSessionService
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

        public void AddSessionSpecs(IEnumerable<CinemaSessionSpec> cinemaSessionSpecs, int cinemaSessionId)
        {
            foreach (var cinemaSessionSpec in cinemaSessionSpecs.Where(
                cinemaSessionSpec =>
                    Database.CinemaSessionSpecs.FindBy(spec => spec.CinemaSessionId == cinemaSessionSpec.CinemaSessionId)
                        .All(spec => spec.CinemaSessionSpecTime != cinemaSessionSpec.CinemaSessionSpecTime)))
            {
                Database.CinemaSessionSpecs.Create(cinemaSessionSpec);
            }
        }

        public void RemoveSessionSpecs(int cinemaSessionId)
        {
            var originalSession = Database.CinemaSessions.Get(cinemaSessionId);
            foreach (var cinemaSessionSpec in originalSession.CinemaSessionSpecs)
            {
                Database.CinemaSessionSpecs.Delete(cinemaSessionSpec);
            }
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
