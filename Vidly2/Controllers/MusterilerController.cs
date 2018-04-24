using System;
using System.Collections.Generic;
using System.Data.Entity;       // for Include(). With Include() UyelikTuru is also sent to the view.
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

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
    }
}