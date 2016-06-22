using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Models;
using ScheduleCinema.Support;

namespace ScheduleCinema.ViewModels
{
    public class CinemaScheduleEditSaveViewModel
    {
        [Key]
        public int CinemaSessionId { get; set; }
        [Display(Name = "Дата расписания")]
        [Required(ErrorMessage = "Необходимо ввести дату")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        public DateTime CinemaSessionDate { get; set; }
        [Display(Name = "Сеансы")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Должен быть хотя бы один сеанс")]
        [TimeFormatAndDuplicate]
        public string CinemaSessionTimes { get; set; }
        [Display(Name = "Фильм")]
        public int MovieId { get; set; }
        [Display(Name = "Кинотеатр")]
        public int CinemaId { get; set; }

        public CinemaScheduleEditSaveViewModel()
        {
        }

        public CinemaScheduleEditSaveViewModel(DateTime scheduleDate)
        {
            CinemaSessionDate = scheduleDate;
        }

        public CinemaScheduleEditSaveViewModel(CinemaSession cinemaSession)
        {
            CinemaSessionId = cinemaSession.CinemaSessionId;
            CinemaSessionDate = cinemaSession.CinemaSessionDate;
            CinemaSessionTimes =
                string.Join("\n", cinemaSession.CinemaSessionSpecs.OrderBy(order => order.CinemaSessionSpecTime)
                    .Select(spec => spec.CinemaSessionSpecTime.ToString(Formats.TimeFormat)));
            MovieId = cinemaSession.MovieId;
            CinemaId = cinemaSession.CinemaId;
        }
    }
}