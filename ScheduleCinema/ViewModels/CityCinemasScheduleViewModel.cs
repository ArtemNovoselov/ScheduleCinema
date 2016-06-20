using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.ViewModels
{
    public class CityCinemasScheduleViewModel
    {
        [Display(Name = "Расписания по кинотеатрам")]
        public IEnumerable<IGrouping<Cinema, CinemaSchedule>> CinemaSchedulesGroups { get; set; }

        [Display(Name = "Дата текущих сеансов")]
        public DateTime ScheduleDate { get; set; }

        public CityCinemasScheduleViewModel(IEnumerable<CinemaSchedule> cinemaSchedules, DateTime date)
        {
            CinemaSchedulesGroups = cinemaSchedules.GroupBy(grouping => grouping.Cinema);
            ScheduleDate = date;
        }

    }
}