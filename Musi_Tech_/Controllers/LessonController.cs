using Microsoft.AspNet.Identity;
using Musi_Tech_.Models;
using Musi_Tech_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musi_Tech_.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonService(userId);
            var model = service.GetLessons();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LessonCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLessonService();

            if (service.CreateLesson(model))
            {
                TempData["SaveResult"] = "Your lesson was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLessonService();
            var model = svc.GetLessonById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLessonService();
            var detail = service.GetLessonById(id);
            var model =
                new LessonEdit
                {
                    LessonId = detail.LessonID,
                    Instrument = detail.Instrument,
                    CustomerId = detail.CustomerID,
                    Date = detail.Date,
                    Cost = detail.Cost
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LessonEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LessonId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLessonService();

            if (service.UpdateLesson(model))
            {
                TempData["SaveResult"] = "Your lesson was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your lesson could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLessonService();
            var model = svc.GetLessonById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLessonService();

            service.DeleteLesson(id);

            TempData["SaveResult"] = "Your lesson was deleted";

            return RedirectToAction("Index");
        }

        private LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonService(userId);
            return service;
        }
    }   
}