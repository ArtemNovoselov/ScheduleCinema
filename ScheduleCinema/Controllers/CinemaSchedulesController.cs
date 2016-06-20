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

namespace ScheduleCinema.Controllers
{
    public class CinemaSchedulesController : Controller
    {
        private readonly ISheduleCinemaRepository _sheduleCinemaRepository;

        public CinemaSchedulesController(ISheduleCinemaRepository sheduleCinemaRepository)
        {
            _sheduleCinemaRepository = sheduleCinemaRepository;
        }
        
        public ActionResult Create()
        {
            var cinemas = _sheduleCinemaRepository.GetCinemas();
            ViewBag.CinemaId = new SelectList(cinemas, "CinemaId", "CinemaAddress");
            return View();
        }

        // POST: CinemaSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinemaScheduleId,CinemaId,ScheduleDate,ScheduleDescription")] CinemaSchedule cinemaSchedule)
        {
            if (ModelState.IsValid)
            {
                _sheduleCinemaRepository.SaveSchedule(cinemaSchedule);
                return RedirectToAction("Index", "Home");
            }

            var cinemas = _sheduleCinemaRepository.GetCinemas();
            ViewBag.CinemaId = new SelectList(cinemas, "CinemaId", "CinemaAddress", cinemaSchedule.CinemaId);
            return View(cinemaSchedule);
        }
        
        public ActionResult Edit(int? id, int? movieId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaSchedule cinemaSchedule = _sheduleCinemaRepository.GetSchedule(id);
            if (cinemaSchedule == null)
            {
                return HttpNotFound();
            }
            var cinemas = _sheduleCinemaRepository.GetCinemas();
            ViewBag.CinemaId = new SelectList(cinemas, "CinemaId", "CinemaAddress", cinemaSchedule.CinemaId);
            return View(cinemaSchedule);
        }

        // POST: CinemaSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinemaScheduleId,CinemaId,ScheduleDate,ScheduleDescription")] CinemaSchedule cinemaSchedule)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            var cinemas = _sheduleCinemaRepository.GetCinemas();
            ViewBag.CinemaId = new SelectList(cinemas, "CinemaId", "CinemaAddress", cinemaSchedule.CinemaId);
            return View(cinemaSchedule);
        }

        // GET: CinemaSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaSchedule cinemaSchedule = _sheduleCinemaRepository.GetSchedule(id);
            if (cinemaSchedule == null)
            {
                return HttpNotFound();
            }
            return View(cinemaSchedule);
        }

        // POST: CinemaSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _sheduleCinemaRepository.DeleteSchedule(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
