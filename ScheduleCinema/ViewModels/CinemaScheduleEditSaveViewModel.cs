using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Models;
using ScheduleCinema.Support;
using ScheduleCinema.Support.DataAnnotationAttributes;
using Cinema = ScheduleCinema.Models.DBMS.MongoDB.Cinema;
using CinemaSession = ScheduleCinema.Models.Interfaces.CinemaSession;
using Movie = ScheduleCinema.Models.Interfaces.Movie;

namespace ScheduleCinema.ViewModels
{
    public class CinemaScheduleEditSaveViewModel
    {
        [Key]
        public int CinemaSessionId { get; set; }

        [Display(Name = "Дата расписания")]
        [Required(ErrorMessage = "Необходимо ввести дату")]
        [DisplayFormat(DataFormatString = Formats.DateFormatAttribute, ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Range(typeof(DateTime), "01.01.2016", "01.01.2018", ErrorMessage = "Дата должна быть от 01.01.2016 до 01.01.2018")]
        public DateTime CinemaSessionDate { get; set; }

        [Display(Name = "Сеансы")]
        [Required(ErrorMessage = "Должен быть хотя бы один сеанс")]
        [DataType(DataType.MultilineText)]
        [TimeFormatAndDuplicate]
        public string CinemaSessionTimes { get; set; }

        [Display(Name = "Фильм")]
        public int MovieId { get; set; }

        [Display(Name = "Кинотеатр")]
        public int CinemaId { get; set; }
        
        public SelectList Movies { get; set; }
        
        public SelectList Cinemas { get; set; }

        public CinemaScheduleEditSaveViewModel()
        {
        }

        public CinemaScheduleEditSaveViewModel(DateTime scheduleDate, IEnumerable<Cinema> cinemas, IEnumerable<Movie> movies)
        {
            CinemaSessionDate = scheduleDate;
            Movies = new SelectList(movies, "MovieId", "MovieName");
            Cinemas = new SelectList(cinemas, "CinemaId", "CinemaName");
        }

        public CinemaScheduleEditSaveViewModel(CinemaSession cinemaSession, IEnumerable<Cinema> cinemas, IEnumerable<Movie> movies)
        {
            CinemaSessionId = cinemaSession.CinemaSessionId;
            CinemaSessionDate = cinemaSession.CinemaSessionDate;
            CinemaSessionTimes =
                string.Join("\n", cinemaSession.CinemaSessionSpecs.OrderBy(order => order.CinemaSessionSpecTime)
                    .Select(spec => spec.CinemaSessionSpecTime.ToString(Formats.TimeFormat)));
            MovieId = cinemaSession.MovieId;
            CinemaId = cinemaSession.CinemaId;

            Movies = new SelectList(movies, "MovieId", "MovieName", cinemaSession.MovieId);
            Cinemas = new SelectList(cinemas, "CinemaId", "CinemaName", cinemaSession.CinemaId);
        }
    }
}