using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class KiralarController : ApiController
    {
        private ApplicationUser.ApplicationDbContext _context;

        public KiralarController()
        {
            _context = new ApplicationUser.ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Kirala(KiraDto yeniKira)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var films = _context.Filmler.Where(m => yeniKira.FilmIds.Contains(m.Id)).ToList();

            var musteri = _context.Musteriler.SingleOrDefault(f => f.Id == yeniKira.MusteriId);

            foreach (var film in films)
            {
                if (film.MevcutSayi == 0)
                {
                    return BadRequest("Üzgünüz, bu film şu anda mevcut değil.");
                }

                film.MevcutSayi--;

                var kira = new Kira
                {
                    Film = film,
                    Musteri = musteri,
                    KiralanmaTarihi = DateTime.Now
                };
                
                _context.Kiralar.Add(kira);
            }

            _context.SaveChanges();

            return Ok();
        }


    }
}