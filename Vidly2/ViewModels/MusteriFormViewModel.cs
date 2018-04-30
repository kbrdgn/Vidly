using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MusteriFormViewModel
    {
        public IEnumerable<UyelikTuru> UyelikTurleri { get; set; }
        public Musteri Musteri { get; set; }

        public string Title
        {
            get
            {
                if (Musteri != null && Musteri.Id != 0)
                {
                    return "Müşteriyi Düzenle";
                }
                return "Yeni Müşteri";

            }
        }







        // public List<UyelikTuru> UyelikTurleri { get; set; } List ile add, remove da var. IEnumarable
        //                                                     ile sadece iterate var, bizim icin yeterli.

    }
}