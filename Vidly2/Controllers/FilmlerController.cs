using System;
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
        private ApplicationDbContext _context;

        public FilmlerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Film
        public ActionResult Index()
        {
            var filmler = _context.Filmler.Include(f => f.Tur).ToList();
            return View(filmler);
        }

        // GET: Filmler/Ayrintilar/id
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