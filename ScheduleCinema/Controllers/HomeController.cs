using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Repositories.Interfaces;
using ScheduleCinema.ViewModels;

namespace ScheduleCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaSessionsRepository _sheduleCinemaRepository;

        public HomeController(ICinemaSessionsRepository sheduleCinemaRepository)
        {
            _sheduleCinemaRepository = sheduleCinemaRepository;
        }

        public ActionResult Index(string scheduleDate)
        {
            List<CinemaScheduleViewModel> cinemasSchedulesView = null;
            ViewBag.Error = "";
            DateTime formattedDate;
            if (string.IsNullOrEmpty(scheduleDate))
            {
                formattedDate = DateTime.Now.Date;
            }
            else
            {
                if (!DateTime.TryParse(scheduleDate, out formattedDate))
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    ViewBag.Error += "Ошибка формата даты\n";
                    return View((List<CinemaScheduleViewModel>) null);
                }
            }

            ViewBag.Date = formattedDate.ToString("dd.MM.yy");
            ViewBag.Title = "Расписания кинотеатров на " + formattedDate.ToString("dd MMMM yyyy");
            var cinemaSessions = _sheduleCinemaRepository.GetCinemasSessions(formattedDate);
            if (cinemaSessions != null)
            {
                cinemasSchedulesView = cinemaSessions.Select(cinemaSession => new CinemaScheduleViewModel(cinemaSession)).OrderBy(order => order.CinemaSessionCinemaName).ToList();
            }
            else
            {
                ViewBag.Error += "Расписания на выбранную дату не найдены\n";
            }
            
            return View(cinemasSchedulesView);
        }
    }
}