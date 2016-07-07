using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.BLL.Interfaces;
using ScheduleCinema.Models;
using ScheduleCinema.Support;
using ScheduleCinema.ViewModels;
using CinemaSession = ScheduleCinema.Models.Interfaces.CinemaSession;
using CinemaSessionSpec = ScheduleCinema.Models.Interfaces.CinemaSessionSpec;

namespace ScheduleCinema.Controllers
{
    public class CinemaSessionsController : Controller
    {
        private readonly ICinemaSessionService _cinemaSessionService;
        public CinemaSessionsController(ICinemaSessionService cinemaSessionService)
        {
            _cinemaSessionService = cinemaSessionService;
        }
        
        public ActionResult Create(string scheduleDate)
        {
            DateTime formattedDate;
            if (!DateTime.TryParseExact(scheduleDate, Formats.DateFormat, null, DateTimeStyles.None, out formattedDate))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(new CinemaScheduleEditSaveViewModel(formattedDate, _cinemaSessionService.GetCinemas(), _cinemaSessionService.GetMovies()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinemaSessionId,CinemaId,MovieId,CinemaSessionDate,CinemaSessionTimes")] CinemaScheduleEditSaveViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var cinemaSession = new CinemaSession
                {
                    CinemaSessionDate = editViewModel.CinemaSessionDate,
                    CinemaId = editViewModel.CinemaId,
                    MovieId = editViewModel.MovieId
                };

                _cinemaSessionService.AddCinemaSession(cinemaSession);

                var newSessionSpecs =
                    editViewModel.CinemaSessionTimes.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(
                        time =>
                            new CinemaSessionSpec()
                            {
                                CinemaSessionId = cinemaSession.CinemaSessionId,
                                CinemaSessionSpecTime = TimeSpan.ParseExact(time, Formats.TimeFormat, CultureInfo.InvariantCulture)
                            }).ToList();

                _cinemaSessionService.AddSessionSpecs(newSessionSpecs);

                return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate.ToString(Formats.DateFormat) });
            }

            editViewModel.Cinemas = new SelectList(_cinemaSessionService.GetCinemas(), "CinemaId", "CinemaName", editViewModel.CinemaId);
            editViewModel.Movies = new SelectList(_cinemaSessionService.GetMovies(), "MovieId", "MovieName", editViewModel.MovieId);
            return View(editViewModel);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaSession cinemaSession = _cinemaSessionService.GetCinemaSession((int)id);
            
            if (cinemaSession == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Редактирование";

            var editViewModel = new CinemaScheduleEditSaveViewModel(cinemaSession, _cinemaSessionService.GetCinemas(), _cinemaSessionService.GetMovies());

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinemaSessionId,CinemaId,MovieId,CinemaSessionDate,CinemaSessionTimes")] CinemaScheduleEditSaveViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var cinemaSession = _cinemaSessionService.GetCinemaSession(editViewModel.CinemaSessionId);
                cinemaSession.CinemaSessionDate = editViewModel.CinemaSessionDate;
                cinemaSession.CinemaId = editViewModel.CinemaId;
                cinemaSession.MovieId = editViewModel.MovieId;

                var newSessionSpecs =
                    editViewModel.CinemaSessionTimes.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(
                        time =>
                            new CinemaSessionSpec()
                            {
                                CinemaSessionId = editViewModel.CinemaSessionId,
                                CinemaSessionSpecTime = TimeSpan.Parse(time)
                            }).ToList();

                _cinemaSessionService.RemoveSessionSpecs(editViewModel.CinemaSessionId);
                _cinemaSessionService.AddSessionSpecs(newSessionSpecs);
                _cinemaSessionService.EditCinemaSession(cinemaSession);
                return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate.ToString(Formats.DateFormat) });
            }

            editViewModel.Cinemas = new SelectList(_cinemaSessionService.GetCinemas(), "CinemaId", "CinemaName", editViewModel.CinemaId);
            editViewModel.Movies = new SelectList(_cinemaSessionService.GetMovies(), "MovieId", "MovieName", editViewModel.MovieId);
            return View(editViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int cinemaSessionId)
        {
            CinemaSession cinemaSession = _cinemaSessionService.GetCinemaSession(cinemaSessionId);
            _cinemaSessionService.RemoveSessionSpecs(cinemaSessionId);
            _cinemaSessionService.RemoveCinemaSession(cinemaSession);
            return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate.ToString(Formats.DateFormat) });
        }

        protected override void Dispose(bool disposing)
        {
            _cinemaSessionService.Dispose();
            base.Dispose(disposing);
        }
    }
}
