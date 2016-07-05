using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.BLL.Interfaces;
using ScheduleCinema.Support;
using ScheduleCinema.ViewModels;

namespace ScheduleCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaSessionService _cinemaSessionService;

        public HomeController(ICinemaSessionService cinemaSessionService)
        {
            _cinemaSessionService = cinemaSessionService;
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
                if (!DateTime.TryParseExact(scheduleDate, Formats.DateFormat, null, DateTimeStyles.None, out formattedDate))
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    ViewBag.Error += Formats.ErrorDateFormatMessage + "\n";
                    return View((List<CinemaScheduleViewModel>) null);
                }
            }

            ViewBag.Date = formattedDate.ToString(Formats.DateFormat);
            ViewBag.Title = "Расписания кинотеатров на " + formattedDate.ToString("dd MMMM yyyy");
            var cinemaSessions = _cinemaSessionService.GetCinemasSessions(formattedDate);
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
        protected override void Dispose(bool disposing)
        {
            _cinemaSessionService.Dispose();
            base.Dispose(disposing);
        }
    }
}