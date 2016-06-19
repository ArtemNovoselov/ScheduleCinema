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
        IEnumerable<Schedule> GetSchedules(DateTime date);
        Schedule GetSchedule(int scheduleId);
        void SaveSchedule(Schedule schedule);
        void EditSchedule(Schedule schedule);
        void DeleteSchedule(int scheduleId);
    }
}