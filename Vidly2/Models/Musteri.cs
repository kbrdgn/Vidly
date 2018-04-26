using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Musteri
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]  // Our column Ad will no longer be nullable with [Required] data annotation.
        [StringLength(255)]     // As the name suggests, specifies length.
        public string Ad { get; set; }

        public bool BulteneAboneMi { get; set; }

        public UyelikTuru UyelikTuru { get; set; }  // a navigation property from customer to its membershipType

        [Required(ErrorMessage = "Lütfen bir üyelik türü seçiniz.")]
        [Display(Name = "Üyelik Türü")]
        public byte UyelikTuruId { get; set; }  // Entity framework recognizes this convention and treats this property as a foreign key.
                                                // Since this is byte, it is implicitly required even though we do not explicitly set
                                                // it as Required.

//        [Display(Name = "Doğum Tarihi")]
        [UyeOlmakIcinMin18Yas]
        public DateTime? DogumTarihi { get; set; }
    }
}