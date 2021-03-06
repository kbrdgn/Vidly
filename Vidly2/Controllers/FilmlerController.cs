﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class FilmlerController : Controller
    {
        private ApplicationUser.ApplicationDbContext _context;

        public FilmlerController()
        {
            _context = new ApplicationUser.ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Film
        public ActionResult Index()
        {
            if (User.IsInRole(RolAdi.CanManageFilms))
                return View("Liste");

            return View("ReadOnlyListe");
        }

        [Authorize(Roles = RolAdi.CanManageFilms)]
        public ActionResult Yeni()
        {
            var turler = _context.Turler.ToList();
            var viewModel = new FilmFormViewModel()
            {
                Turler = turler
            };

            return View("FilmForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolAdi.CanManageFilms)]
        public ActionResult Kaydet(Film film)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FilmFormViewModel()
                {
                    Film = film,
                    Turler = _context.Turler.ToList()
                };

                return View("FilmForm", viewModel);      // if not valid, return the same view.
            }

            if (film.Id == 0)
            {
                film.EklenmeTarihi = DateTime.Now;
                _context.Filmler.Add(film);                
            }
            else
            {
                var filmInDb = _context.Filmler.Single(f => f.Id == film.Id);

                filmInDb.Ad = film.Ad;
                filmInDb.VizyonTarihi = film.VizyonTarihi;
                filmInDb.TurId = film.TurId;
                filmInDb.StoktakiSayi = film.StoktakiSayi;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Filmler");
        }

        [Authorize(Roles = RolAdi.CanManageFilms)]
        public ActionResult Duzenle(int id)
        {
            var film = _context.Filmler.SingleOrDefault(f => f.Id == id);

            if (film == null)
            {
                return HttpNotFound();
            }

            var viewModel = new FilmFormViewModel
            {
                Film = film,
                Turler =  _context.Turler.ToList()
            };
            
            return View("FilmForm", viewModel);
        }

        // GET: Filmler/Ayrintilar/id
        [Authorize(Roles = RolAdi.CanManageFilms)]
        public ActionResult Ayrintilar(int id)
        {
            var film = _context.Filmler.Include(f => f.Tur).SingleOrDefault(f => f.Id == id);

            if (film == null)
                return HttpNotFound();

            return View(film);
        }

        // GET: Filmler/Rastgele
        public ActionResult Rastgele()
        {
            var film = new Film() { Ad = "Dr. Strange!" };
            var musteriler = new List<Musteri>
            {
                new Musteri { Ad = "Customer 1" },
                new Musteri { Ad = "Customer 2" }
            };

            var viewModel = new RastgeleFilmViewModel
            {
                Film = film,
                Musteriler = musteriler
            };

            return View(viewModel);
        }
    }
}