using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class MusterilerController : ApiController
    {
        private ApplicationUser.ApplicationDbContext _context;

        public MusterilerController()
        {
            _context = new ApplicationUser.ApplicationDbContext();
        }

        // GET /api/musteriler
        [HttpGet]
        public IHttpActionResult MusterileriGetir(string query = null)
        {
            var musterilerSorgu = _context.Musteriler
                .Include(c => c.UyelikTuru);

            if (!String.IsNullOrWhiteSpace(query))
                musterilerSorgu = musterilerSorgu.Where(c => c.Ad.Contains(query));

            var musterilerDtos = musterilerSorgu.
                ToList().
                Select(Mapper.Map<Musteri, MusteriDto>);

            return Ok(musterilerDtos);
        }

        // GET /api/musteriler/1
        [HttpGet]
        public IHttpActionResult MusteriyiGetir(int id)
        {
            var musteri = _context.Musteriler.SingleOrDefault(c => c.Id == id);

            if (musteri == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Musteri,MusteriDto>(musteri));
        }

        // POST /api/musteriler
        [HttpPost]
        public IHttpActionResult MusteriOlustur(MusteriDto musteriDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var musteri = Mapper.Map<MusteriDto, Musteri>(musteriDto);
            _context.Musteriler.Add(musteri);
            _context.SaveChanges();

            musteriDto.Id = musteri.Id;

            return Created(new Uri(Request.RequestUri + "/" + musteri.Id), musteriDto);
        }

        // PUT /api/musteriler
        [HttpPut]
        public IHttpActionResult MusteriyiGuncelle(int id, MusteriDto musteriDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var musteriInDb = _context.Musteriler.SingleOrDefault(c => c.Id == id);

            if (musteriInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<MusteriDto, Musteri>(musteriDto, musteriInDb);            

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/musteriler/1
        [HttpDelete]
        public IHttpActionResult MusteriyiSil(int id)
        {
            var musteriInDb = _context.Musteriler.SingleOrDefault(c => c.Id == id);

            if (musteriInDb == null)
            {
                return NotFound();
            }

            _context.Musteriler.Remove(musteriInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
