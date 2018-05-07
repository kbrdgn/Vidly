using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class FilmlerController : ApiController
    {
        private ApplicationUser.ApplicationDbContext _context;

        public FilmlerController()
        {
            _context = new ApplicationUser.ApplicationDbContext();
        }

        // GET /api/filmler
        [HttpGet]
        public IHttpActionResult GetFilmler(string query = null)
        {
            var filmlerSorgu = _context.Filmler.Include(f => f.Tur).Where(f => f.MevcutSayi > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                filmlerSorgu = filmlerSorgu.Where(f => f.Ad.Contains(query));
            }

            var filmlerDtos = filmlerSorgu.
                ToList().
                Select(Mapper.Map<Film, FilmDto>);

            return Ok(filmlerDtos);            
        }

        // GET /api/filmler/1
        [HttpGet]
        public IHttpActionResult FilmiGetir(int id)
        {
            var film = _context.Filmler.SingleOrDefault(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Film, FilmDto>(film));
        }

        // POST /api/filmler
        [HttpPost]
        [Authorize(Roles = RolAdi.CanManageFilms)]
        public IHttpActionResult FilmOlustur(FilmDto filmDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var film = Mapper.Map<FilmDto, Film>(filmDto);

            _context.Filmler.Add(film);
            _context.SaveChanges();

            filmDto.Id = film.Id;

            return Created(new Uri(Request.RequestUri + "/" + film.Id), filmDto);
        }

        // PUT /api/filmler
        [HttpPut]
        [Authorize(Roles = RolAdi.CanManageFilms)]
        public IHttpActionResult FimiGuncelle(int id, FilmDto filmDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var filmInDb = _context.Filmler.SingleOrDefault(f => f.Id == id);

            if (filmInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<FilmDto, Film>(filmDto, filmInDb); // 1. = source   2. = destination

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/filmler/
        [HttpDelete]
        [Authorize(Roles = RolAdi.CanManageFilms)]
        public IHttpActionResult FilmiSil(int id)
        {
            var filmInDb = _context.Filmler.SingleOrDefault(f => f.Id == id);

            if (filmInDb == null)
            {
                return NotFound();
            }

            _context.Filmler.Remove(filmInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}
