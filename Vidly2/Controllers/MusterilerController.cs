using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        public ActionResult Index()
        {
            var musteriler = MusterileriGetir();
            return View(musteriler);
        }

        public ActionResult Ayrintilar(int id)
        {
            var musteri = MusterileriGetir().SingleOrDefault(c => c.Id == id);

            if (musteri == null)
            {
                return HttpNotFound();
            }

            return View(musteri);
        }


        private IEnumerable<Musteri> MusterileriGetir()
        {
            return new List<Musteri>
            {
                new Musteri {Id = 1, Ad = "John Smith"},
                new Musteri {Id = 2, Ad = "Mary Williams"}
            };
        }
    }
}