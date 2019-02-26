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
    public class LessonRequestController : Controller
    {
        // GET: LessonRequest
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonRequestService(userId);
            var model = service.GetLessonRequests();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LessonRequestCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLessonRequestService();

            if (service.CreateLessonRequest(model))
            {
                TempData["SaveResult"] = "Your request was sent.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Request could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLessonRequestService();
            var model = svc.GetLessonRequestByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLessonRequestService();
            var detail = service.GetLessonRequestByID(id);
            var model =
                new LessonRequestEdit
                {
                    LessonRequestID = detail.LessonRequestID,
                    CustomerFullName = detail.CustomerFullName,
                    Instrument = detail.Instrument,
                    RequestStartDate = detail.RequestedStartDate,
                    ZipCode = detail.ZipCode
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, LessonRequestEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LessonRequestID != ID)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLessonRequestService();

            if (service.UpdateLessonRequest(model))
            {
                TempData["SaveResult"] = "Your request was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your request could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLessonRequestService();
            var model = svc.GetLessonRequestByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLessonRequestService();

            service.DeleteLessonRequest(id);

            TempData["SaveResult"] = "Your request was deleted";

            return RedirectToAction("Index");
        }

        private LessonRequestService CreateLessonRequestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonRequestService(userId);
            return service;
        }
    }
}