using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;
using ScheduleCinema.Support;
using CinemaSession = ScheduleCinema.Models.Interfaces.CinemaSession;

namespace ScheduleCinema.ViewModels
{
    public class CinemaScheduleViewModel
    {
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Список сеансов")]
        [MinLength(1, ErrorMessage = ErrorMessages.ErrorDateSessionsMessage)]
        public IEnumerable<CinemaSession> CinemaSessions { get; set; }

        [Display(Name = "Дата")]
        public string CinemaScheduleDate { get; set; }

        public CinemaScheduleViewModel(IEnumerable<CinemaSession> cinemaSessions, string scheduleDate)
        {
            CinemaScheduleDate = scheduleDate;
            CinemaSessions = cinemaSessions;
            Title = "Расписания кинотеатров на " + scheduleDate;
        }
    }
}