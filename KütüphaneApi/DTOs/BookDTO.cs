using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BookDTO
    {
        public string KitapAdi { get; set; }
        public int SayfaSayisi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public int YayinEviId { get; set; }
        public int YazarId { get; set; }
        public int KategoriId { get; set; }
    }
}
