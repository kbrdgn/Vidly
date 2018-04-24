using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Tur
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Ad { get; set; }
    }
}