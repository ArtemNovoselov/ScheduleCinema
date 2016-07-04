using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.Models;

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
