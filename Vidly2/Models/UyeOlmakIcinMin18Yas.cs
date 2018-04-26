using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class UyeOlmakIcinMin18Yas : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var musteri = (Musteri) validationContext.ObjectInstance;

            if (musteri.UyelikTuruId == UyelikTuru.Bilinmeyen || musteri.UyelikTuruId == UyelikTuru.HarcadikcaOde)
            {
                return ValidationResult.Success;
            }

            if (musteri.DogumTarihi == null)
            {
                return new ValidationResult("Lütfen doğum tarihinizi giriniz.");
            }

            var age = DateTime.Today.Year - musteri.DogumTarihi.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Üye olmak için en az 18 yaşında olmalısınız.");
        }
    }
}