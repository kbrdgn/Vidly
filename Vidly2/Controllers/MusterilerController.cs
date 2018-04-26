using System;
using System.Collections.Generic;
using System.Data.Entity;       // for Include(). With Include() UyelikTuru is also sent to the view.
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MusterilerController : Controller
    {
        private ApplicationDbContext _context;      // We need a DbContext to access the database. Initialize it in the constructor.

        public MusterilerController()
        {
            _context = new ApplicationDbContext(); // dbContext is a disposable (tek kullanımlık) object.
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Yeni()
        {
            var uyelikTurleri = _context.UyelikTurleri.ToList();
            var viewModel = new MusteriFormViewModel
            {
                Musteri = new Musteri(),
                UyelikTurleri = uyelikTurleri
            };

            return View("MusteriForm", viewModel);
        }

        // Eger action larimiz modify data yapiyorsa HttpGet tarafindan erisilmemeli, Post oldugunu garantiledik.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Musteri musteri) // model binding
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MusteriFormViewModel
                {
                    Musteri =  musteri,
                    UyelikTurleri = _context.UyelikTurleri.ToList()
                };

                return View("MusteriForm", viewModel);      // if not valid, return the same view.
            }

            

            if (musteri.Id == 0)
            {
                _context.Musteriler.Add(musteri);
            }
            else
            {
                var musteriInDb = _context.Musteriler.Single(m => m.Id == musteri.Id);
                musteriInDb.Ad = musteri.Ad;
                musteriInDb.DogumTarihi = musteri.DogumTarihi;
                musteriInDb.UyelikTuru = musteri.UyelikTuru;
                musteriInDb.BulteneAboneMi = musteri.BulteneAboneMi;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Musteriler");
        }

        // GET: Musteriler
        public ActionResult Index()
        {
            var musteriler = _context.Musteriler.Include(c => c.UyelikTuru).ToList();   // we can get all Musteriler in the database. Queried immediately using ToList().
            //var musteriler = _context.Musteriler;
            // When the above line is executed, entity framework is not going to query the database. This is what we call deferred execution.
            // The queries are actually executed when we iterate over this musteriler object. (see Index view)
            // if we call like _context.Musteriler.ToList(), it is immediately executed in the database.
            return View(musteriler);
        }

        public ActionResult Ayrintilar(int id)
        {
            var musteri = _context.Musteriler.Include(c => c.UyelikTuru).SingleOrDefault(c => c.Id == id);     // because of SingleOrDefault method, query is immediately executed again.

            if (musteri == null)
            {
                return HttpNotFound();
            }

            return View(musteri);
        }

        public ActionResult Duzenle(int id)
        {
            var musteri = _context.Musteriler.SingleOrDefault(m => m.Id == id);

            if (musteri == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MusteriFormViewModel
            {
                Musteri =  musteri,
                UyelikTurleri = _context.UyelikTurleri.ToList()
            };

            return View("MusteriForm", viewModel);
        }
    }
}