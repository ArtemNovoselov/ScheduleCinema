using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCinema.DAL.EF;
using ScheduleCinema.DAL.Interfaces;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ScheduleCinemaDbContext _db;
        private CinemaSessionsRepository _cinemaSessionsRepository;
        private CinemasRepository _cinemasRepository;
        private MoviesRepository _moviesRepository;
        private CinemaSessionSpecsRepository _cinemaSessionSpecsRepository;

        public EFUnitOfWork(string connectionString)
        {
            _db = new ScheduleCinemaDbContext(connectionString);
        }

        public IGenericRepository<ICinema> Cinemas
        {
            get
            {
                if (_cinemasRepository == null)
                {
                    _cinemasRepository = new CinemasRepository(_db);
                }
                return _cinemasRepository;
            }
        }

        public IGenericRepository<ICinemaSession> CinemaSessions
        {
            get
            {
                if (_cinemaSessionsRepository == null)
                {
                    _cinemaSessionsRepository = new CinemaSessionsRepository(_db);
                }
                return _cinemaSessionsRepository;
            }
        }

        public IGenericRepository<ICinemaSessionSpec> CinemaSessionSpecs
        {
            get
            {
                if (_cinemaSessionSpecsRepository == null)
                {
                    _cinemaSessionSpecsRepository = new CinemaSessionSpecsRepository(_db);
                }
                return _cinemaSessionSpecsRepository;
            }
        }

        public IGenericRepository<IMovie> Movies {
            get
            {
                if (_moviesRepository == null)
                {
                    _moviesRepository = new MoviesRepository(_db);
                }
                return _moviesRepository;
            }
        }

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
