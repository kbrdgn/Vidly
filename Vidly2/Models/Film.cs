using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen bir film adı giriniz.")]
        [StringLength(255)]
        public string Ad { get; set; }

        public Tur Tur { get; set; }

        [Required(ErrorMessage = "Lütfen bir tür seçiniz.")]
        [Display(Name = "Tür")]
        public byte TurId { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        [Required(ErrorMessage = "Lütfen vizyon tarihini giriniz.")]
        public DateTime VizyonTarihi { get; set; }

        [Required(ErrorMessage = "Lütfen stok sayısını giriniz.")]
        [Range(1, 20, ErrorMessage = "Stoktaki sayı 1 ile 20 arasında bir değer olmalıdır.")]
        public byte StoktakiSayi { get; set; }

        [Required]
        public byte MevcutSayi { get; set; }
    }
}