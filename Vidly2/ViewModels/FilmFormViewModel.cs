using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class FilmFormViewModel
    {
        public IEnumerable<Tur> Turler { get; set; }
        public Film Film { get; set; }

        public string Title
        {
            get
            {
                if (Film != null && Film.Id != 0)
                {
                    return "Filmi Düzenle";
                }
                return "Yeni Film";

            }
        }
    }
}