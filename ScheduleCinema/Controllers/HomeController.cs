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
            CityCinemasScheduleViewModel scheduleView = null;
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
                    return View((CityCinemasScheduleViewModel) null);
                }
            }

            ViewBag.Date = formattedDate.ToString("dd.MM.yy");
            ViewBag.Title = "Расписание кинотеатров города Гадюкино за " + formattedDate.Date;

            var schedules = _sheduleCinemaRepository.GetSchedules(formattedDate);
            if (schedules != null)
            {
                scheduleView = new CityCinemasScheduleViewModel(schedules.ToList(), formattedDate);
            }
            else
            {
                ViewBag.Error += "Расписания за выбранную дату не найдены\n";
            }
            
            return View(scheduleView);
        }
    }
}