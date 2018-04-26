using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class UyelikTuru
    {
        public byte Id { get; set; }    // byte because we don't need more than a few membership types.
        [Required] public string Ad { get; set; }
        public short KayitUcreti { get; set; }  // short because we don't need any value more than 32,000.
        public byte SureAyCinsinden { get; set; }   // byte because we don't need value more than 12.
        public byte IndirimOrani { get; set; }  // percentage between 0 and 100.

        public static readonly byte Bilinmeyen = 0;
        public static readonly byte HarcadikcaOde = 1;

    }
}