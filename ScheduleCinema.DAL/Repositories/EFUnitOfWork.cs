using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.DAL.EF;
using ScheduleCinema.DAL.Interfaces;
using ScheduleCinema.DAL.Models;

namespace ScheduleCinema.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ScheduleCinemaDbContext _db;
        private CinemaSessionsRepository _cinemaSessionRepository;
        private CinemasRepository _cinemaSessionRepository;
        private CinemaSessionsRepository _cinemaSessionRepository;
        private CinemaSessionsRepository _cinemaSessionRepository;

        public EFUnitOfWork(string connectionString)
        {
            _db = new ScheduleCinemaDbContext(connectionString);
        }

        public IGenericRepository<Cinema> Cinemas { get; }

        public IGenericRepository<CinemaSession> CinemaSessions
        {
            get
            {
                if (_cinemaSessionRepository == null)
                {
                    _cinemaSessionRepository = new CinemaSessionsRepository(_db);
                }
                return _cinemaSessionRepository;
            }
        }

        public IGenericRepository<CinemaSessionSpec> CinemaSessionSpecs { get; }
        public IGenericRepository<Movie> Movies { get; }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
