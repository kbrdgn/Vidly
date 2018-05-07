using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class KiraDto
    {
        public int MusteriId { get; set; }
        public List<int> FilmIds { get; set; }
    }
}