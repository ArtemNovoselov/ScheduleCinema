using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.Models;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ICinema> Cinemas { get; }
        IGenericRepository<ICinemaSession> CinemaSessions { get; }
        IGenericRepository<ICinemaSessionSpec> CinemaSessionSpecs { get; }
        IGenericRepository<IMovie> Movies { get; }
        void Save();
    }
}
