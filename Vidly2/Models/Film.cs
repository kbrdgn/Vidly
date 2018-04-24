﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Ad { get; set; }

        [Required] public Tur Tur { get; set; }
        public byte TurId { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public DateTime VizyonTarihi { get; set; }

        public byte StoktakiSayi { get; set; }
    }
}