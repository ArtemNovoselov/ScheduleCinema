using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Models;

namespace ScheduleCinema.ViewModels
{
    public class CinemaScheduleEditViewModel
    {
        [Key]
        public int CinemaSessionId { get; set; }
        [Display(Name = "Дата расписания")]
        []
        public DateTime CinemaSessionDate { get; set; }
        //[Display(Name = "Сеансы")]
        //public string[] CinemaSessionTimes { get; set; }
        [Display(Name = "Фильм")]
        public int MovieId { get; set; }
        [Display(Name = "Кинотеатр")]
        public int CinemaId { get; set; }

        public CinemaScheduleEditViewModel()
        {
        }

        public CinemaScheduleEditViewModel(CinemaSession cinemaSession)
        {
            CinemaSessionId = cinemaSession.CinemaSessionId;
            CinemaSessionDate = cinemaSession.CinemaSessionDate;
            /*CinemaSessionTimes =
                cinemaSession.CinemaSessionSpecs.OrderBy(order => order.CinemaSessionSpecTime)
                    .Select(spec => spec.CinemaSessionSpecTime.ToString(@"hh\:mm"))
                    .ToArray();*/
            MovieId = cinemaSession.MovieId;
            CinemaId = cinemaSession.CinemaId;
        }

    }
}