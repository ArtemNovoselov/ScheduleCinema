using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Models;
using ScheduleCinema.Repositories.Interfaces;
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
        
        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(_sheduleCinemaRepository.GetCinemas(), "CinemaId", "CinemaName");
            ViewBag.MovieId = new SelectList(_sheduleCinemaRepository.GetMovies(), "MovieId", "MovieName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinemaSessionId,CinemaId,MovieId,CinemaSessionDate")] CinemaSession cinemaSession)
        {
            if (ModelState.IsValid)
            {
                _sheduleCinemaRepository.Create(cinemaSession);
                return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate });
            }

            ViewBag.CinemaId = new SelectList(_sheduleCinemaRepository.GetCinemas(), "CinemaId", "CinemaName", cinemaSession.CinemaId);
            ViewBag.MovieId = new SelectList(_sheduleCinemaRepository.GetMovies(), "MovieId", "MovieName", cinemaSession.MovieId);
            return View(cinemaSession);
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

            var editViewModel = new CinemaScheduleEditViewModel(cinemaSession);
            ViewBag.CinemaId = new SelectList(_sheduleCinemaRepository.GetCinemas(), "CinemaId", "CinemaName", cinemaSession.CinemaId);
            ViewBag.MovieId = new SelectList(_sheduleCinemaRepository.GetMovies(), "MovieId", "MovieName", cinemaSession.MovieId);

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinemaSessionId,CinemaId,MovieId,CinemaSessionDate,CinemaSessionTimes")] CinemaScheduleEditViewModel editViewModel)
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

                _sheduleCinemaRepository.AddSessionSpecs(newSessionSpecs, editViewModel.CinemaSessionId);
                _sheduleCinemaRepository.Edit(cinemaSession);
                return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate });
            }

            ViewBag.CinemaId = new SelectList(_sheduleCinemaRepository.GetCinemas(), "CinemaId", "CinemaName", editViewModel.CinemaId);
            ViewBag.MovieId = new SelectList(_sheduleCinemaRepository.GetMovies(), "MovieId", "MovieName", editViewModel.MovieId);
            return View(editViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            CinemaSession cinemaSession = _sheduleCinemaRepository.GetCinemaSession(id);
            _sheduleCinemaRepository.Delete(cinemaSession);
            return RedirectToAction("Index", "Home", new { scheduleDate = cinemaSession.CinemaSessionDate});
        }
    }
}
