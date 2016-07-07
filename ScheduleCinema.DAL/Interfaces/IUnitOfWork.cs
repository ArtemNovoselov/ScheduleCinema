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

namespace ScheduleCinema.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Cinema> Cinemas { get; }
        IGenericRepository<CinemaSession> CinemaSessions { get; }
        IGenericRepository<CinemaSessionSpec> CinemaSessionSpecs { get; }
        IGenericRepository<Movie> Movies { get; }
        void Save();
    }
}
