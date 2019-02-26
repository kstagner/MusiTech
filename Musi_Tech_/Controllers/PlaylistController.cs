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
    public class PlaylistController : Controller
    {
        // GET: Playlist
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlaylistService(userId);
            var model = service.GetSongs();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlaylistService(userId);

            service.CreatePlaylist(model);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlaylistService();
            var model = svc.GetPlaylistById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlaylistService();
            var detail = service.GetPlaylistById(id);
            var model =
                new PlaylistEdit
                {
                    SongID = detail.SongID,
                    SongTitle = detail.SongTitle,
                    Artist = detail.Artist,
                    Genre = detail.Genre
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlaylistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SongID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlaylistService();

            if (service.UpdatePlaylist(model))
            {
                TempData["SaveResult"] = "Your playlist was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your playlist could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlaylistService();
            var model = svc.GetPlaylistById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlaylistService();

            service.DeletePlaylist(id);

            TempData["SaveResult"] = "Your song was deleted";

            return RedirectToAction("Index");
        }

        private PlaylistService CreatePlaylistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlaylistService(userId);
            return service;
        }
    }
}