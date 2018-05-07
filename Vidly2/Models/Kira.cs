using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Kira
    {
        public int Id { get; set; }

        [Required]
        public Musteri Musteri { get; set; }

        [Required]
        public Film Film { get; set; }

        public DateTime KiralanmaTarihi { get; set; }
        public DateTime? GeriVermeTarihi { get; set; }
    }
}