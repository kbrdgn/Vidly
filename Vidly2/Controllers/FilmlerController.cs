using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class FilmlerController : Controller
    {
        // GET: Film
        public ActionResult Index()
        {
            var filmler = FilmleriGetir();
            return View(filmler);
        }


        private IEnumerable<Film> FilmleriGetir()
        {
            return new List<Film>
            {
                new Film { Id = 1, Ad = "Dr. Strange" },
                new Film { Id = 2, Ad = "The Shawshank Redemption" }
            };
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