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

        [Required]  // Our column Ad will no longer be nullable with [Required] data annotation.
        [StringLength(255)]     // As the name suggests, specifies length.

        public string Ad { get; set; }

        public bool BulteneAboneMi { get; set; }

        public UyelikTuru UyelikTuru { get; set; }  // a navigation property from customer to its membershipType

        [Display(Name = "Üyelik Türü")]
        public byte UyelikTuruId { get; set; }  // Entity framework recognizes this convention and treats this property as a foreign key.

//        [Display(Name = "Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }
    }
}