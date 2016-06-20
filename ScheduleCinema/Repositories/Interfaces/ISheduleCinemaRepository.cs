using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.Repositories.Interfaces
{
    public interface ISheduleCinemaRepository
    {
        IEnumerable<Cinema> GetCinemas();
        IEnumerable<Movie> GetMovies();
        IEnumerable<CinemaSchedule> GetSchedules(DateTime date);
        CinemaSchedule GetSchedule(int? scheduleId);
        void SaveSchedule(CinemaSchedule cinemaSchedule);
        void EditSchedule(CinemaSchedule cinemaSchedule);
        void DeleteSchedule(int scheduleId);
    }
}