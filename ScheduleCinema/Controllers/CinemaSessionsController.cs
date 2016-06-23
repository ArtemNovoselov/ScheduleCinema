using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Models;
using ScheduleCinema.Repositories.Interfaces;
using ScheduleCinema.Support;
using ScheduleCinema.ViewModels;

namespace ScheduleCinema.Controllers
{
    public class CinemaSessionsController : Controller
    {
        private readonly ICinemaSessionsRepository _sheduleCinemaRepository;
        public CinemaSessionsController(ICinemaSessionsRepository sheduleCinemaRepository)
        {
            _sheduleCinemaRepository = sheduleCinemaRepository;
        }
        
        public ActionResult Create(string scheduleDate)
        {
            DateTime formattedDate;
            if (!DateTime.TryParseExact(scheduleDate, Formats.DateFormat, null, DateTimeStyles.None, out formattedDate))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(new CinemaScheduleEditSaveViewModel(formattedDate, _sheduleCinemaRepository.GetCinemas(), _sheduleCinemaRepository.GetMovies()));
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

                var newSessionSpecs =
                    editViewModel.CinemaSessionTimes.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(
                        time =>
                            new CinemaSessionSpec()
                            {
                                CinemaSessionId = editViewModel.CinemaSessionId,
                                CinemaSessionSpecTime = TimeSpan.ParseExact(time, Formats.TimeFormat, CultureInfo.InvariantCulture)
                            }).ToList();

                var newSessionId = _sheduleCinemaRepository.Create(cinemaSession);
                _sheduleCinemaRepository.AddSessionSpecs(newSessionSpecs, newSessionId);
                _sheduleCinemaRepository.Save();

                return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate.ToString(Formats.DateFormat) });
            }

            editViewModel.Cinemas = new SelectList(_sheduleCinemaRepository.GetCinemas(), "CinemaId", "CinemaName", editViewModel.CinemaId);
            editViewModel.Movies = new SelectList(_sheduleCinemaRepository.GetMovies(), "MovieId", "MovieName", editViewModel.MovieId);
            return View(editViewModel);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaSession cinemaSession = _sheduleCinemaRepository.GetCinemaSession((int)id);
            
            if (cinemaSession == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Редактирование";

            var editViewModel = new CinemaScheduleEditSaveViewModel(cinemaSession, _sheduleCinemaRepository.GetCinemas(), _sheduleCinemaRepository.GetMovies());

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinemaSessionId,CinemaId,MovieId,CinemaSessionDate,CinemaSessionTimes")] CinemaScheduleEditSaveViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var cinemaSession = _sheduleCinemaRepository.GetCinemaSession(editViewModel.CinemaSessionId);
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

                _sheduleCinemaRepository.RemoveSessionSpecs(editViewModel.CinemaSessionId);
                _sheduleCinemaRepository.Save();
                _sheduleCinemaRepository.AddSessionSpecs(newSessionSpecs, editViewModel.CinemaSessionId);
                _sheduleCinemaRepository.Edit(cinemaSession);
                _sheduleCinemaRepository.Save();
                return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate.ToString(Formats.DateFormat) });
            }

            editViewModel.Cinemas = new SelectList(_sheduleCinemaRepository.GetCinemas(), "CinemaId", "CinemaName", editViewModel.CinemaId);
            editViewModel.Movies = new SelectList(_sheduleCinemaRepository.GetMovies(), "MovieId", "MovieName", editViewModel.MovieId);
            return View(editViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int cinemaSessionId)
        {
            CinemaSession cinemaSession = _sheduleCinemaRepository.GetCinemaSession(cinemaSessionId);
            _sheduleCinemaRepository.RemoveSessionSpecs(cinemaSessionId);
            _sheduleCinemaRepository.Delete(cinemaSession);
            _sheduleCinemaRepository.Save();
            return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate.ToString(Formats.DateFormat) });
        }
    }
}
