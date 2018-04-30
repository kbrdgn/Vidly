using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class MusteriDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        [StringLength(255)]
        public string Ad { get; set; }

        public bool BulteneAboneMi { get; set; }       

        [Required(ErrorMessage = "Lütfen bir üyelik türü seçiniz.")]
        public byte UyelikTuruId { get; set; }

        public UyelikTuruDto UyelikTuru { get; set; }

//        [UyeOlmakIcinMin18Yas]
        public DateTime? DogumTarihi { get; set; }
    }
}