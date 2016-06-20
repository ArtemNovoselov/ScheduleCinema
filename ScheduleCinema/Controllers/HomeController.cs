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
        private readonly ISheduleCinemaRepository _sheduleCinemaRepository;

        public HomeController(ISheduleCinemaRepository sheduleCinemaRepository)
        {
            _sheduleCinemaRepository = sheduleCinemaRepository;
        }

        public ActionResult Index(string scheduleDate)
        {
            CinemasScheduleViewModel scheduleView = null;
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
                    ViewBag.Error += "Ошибка формата даты\n";
                    return View((CinemasScheduleViewModel) null);
                }
            }

            ViewBag.Date = formattedDate.ToString("dd.MM.yy");
            ViewBag.Title = "Расписание кинотеатров города Гадюкино за " + formattedDate.Date;

            var cinemaSessions = _sheduleCinemaRepository.GetCinemsSessions(formattedDate);
            if (cinemaSessions != null)
            {
                scheduleView = new CinemasScheduleViewModel(cinemaSessions.ToList(), formattedDate);
            }
            else
            {
                ViewBag.Error += "Расписания за выбранную дату не найдены\n";
            }
            
            return View(scheduleView);
        }
    }
}