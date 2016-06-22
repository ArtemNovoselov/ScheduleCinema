using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.ViewModels
{
    public class CinemaScheduleViewModel
    {
        [Key]
        public int CinemaSessionId { get; set; }
        [Display(Name = "Фильм")]
        public string CinemaSessionMovieName { get; set; }
        [Display(Name = "Кинотеатр")]
        public string CinemaSessionCinemaName { get; set; }
        [Display(Name = "Сеансы")]
        public string CinemaSessionTimes { get; set; }

        public CinemaScheduleViewModel(CinemaSession cinemaSession)
        {
            CinemaSessionId = cinemaSession.CinemaSessionId;
            CinemaSessionMovieName = cinemaSession.Movie.MovieName;
            CinemaSessionCinemaName = cinemaSession.Cinema.CinemaName;
            CinemaSessionTimes = string.Join(",",
                cinemaSession.CinemaSessionSpecs.OrderBy(order => order.CinemaSessionSpecTime)
                    .Select(spec => spec.CinemaSessionSpecTime.ToString(@"hh\:mm"))
                    .ToArray());
        }
    }
}