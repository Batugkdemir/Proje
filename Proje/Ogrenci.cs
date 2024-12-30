using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    internal class Ogrenci
    {
        public int OgrenciId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }

        //Forein Key
        public int SinifId { get; set; }
        
        //Navigation Property yani nesneler arası ilişkiyi ifade etmek için kullanıyoruz
        public Sinif Sinif { get; set; }

        //Tabloya veri ekleyebilmek için IColleciton gerekiyor
        public ICollection<OgrenciDers> OgrenciDersler { get; set; }

        public override string ToString()
        {
            return $"Ad:{this.Ad}-Soyad:{this.Soyad}-Numara:{this.Numara}";
        }
    }
    internal class Sinif 
    {
        [Column(TypeName = "int")]
        [MaxLength(20)]
        [Required]
        public int SinifId { get; set; }

        public string SinifAd { get; set; }

        public int Kontenjan { get;set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }
    }

    internal class OgrenciDers 
    {
        public int DersId { get; set; }
        public Dersler Dersler { get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }


    }

    internal class Dersler 
    {
        [Column(TypeName = "int")]
        [MaxLength(20)]
        [Required]
        public int DersId { get; set; }
        

        public string DersKod { get; set; }

        public string DersAd { get; set; }

        public ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}