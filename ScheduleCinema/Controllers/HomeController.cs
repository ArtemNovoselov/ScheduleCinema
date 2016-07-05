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
        private readonly DateTime _currentDate;

        public HomeController(ICinemaSessionService cinemaSessionService)
        {
            _cinemaSessionService = cinemaSessionService;
            _currentDate = DateTime.Now;
        }

        [DateValidation]
        public ActionResult Index(string scheduleDate)
        {
            List<CinemaScheduleViewModel> cinemasSchedulesView = null;
            if (ModelState.IsValid)
            {
                ViewBag.Date = scheduleDate;
                ViewBag.Title = "Расписания кинотеатров на " + scheduleDate;
                var cinemaSessions = _cinemaSessionService.GetCinemasSessions(DateTime.Parse(scheduleDate));
                if (cinemaSessions != null)
                {
                    cinemasSchedulesView = cinemaSessions.Select(cinemaSession => new CinemaScheduleViewModel(cinemaSession)).OrderBy(order => order.CinemaSessionCinemaName).ToList();
                }
                else
                {
                   ModelState.AddModelError("", ErrorMessages.ErrorDateSessionsMessage);
                }
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