using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.BLL.Interfaces;
using ScheduleCinema.Support;
using ScheduleCinema.Support.ActionAttributes;
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

        [DateValidation]
        public ActionResult Index(string scheduleDate)
        {
            CinemaScheduleViewModel cinemasSchedulesView = null;
            if (ModelState.IsValid)
            {
                var cinemaSessions = _cinemaSessionService.GetCinemasSessions(DateTime.Parse(scheduleDate));
                cinemasSchedulesView = new CinemaScheduleViewModel(cinemaSessions.OrderBy(order => order.Cinema.CinemaName).ToList(), scheduleDate);
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