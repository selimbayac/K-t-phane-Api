using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public int SayfaSayisi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }

        // Foreign Keys
        public int YayinEviId { get; set; }
        public Publisher YayinEvi { get; set; }

        public int YazarId { get; set; }
        public Author Yazar { get; set; }

        public int KategoriId { get; set; }
        public Category Kategori { get; set; }
    }
}
