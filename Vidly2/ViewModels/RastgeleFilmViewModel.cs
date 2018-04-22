using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class RastgeleFilmViewModel
    {
        public Film Film { get; set; }
        public List<Musteri> Musteriler { get; set; }
    }
}