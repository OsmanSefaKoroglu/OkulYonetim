using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okulyönetimuygulaması
{
    internal class Ogrenci
    {

        public int No {  get; set; }

        public string Ad {  get; set; }

        public string Soyad { get; set; }

        public DateTime DogumTarihi {  get; set; }

        public SUBE SUBE { get; set; }

        public CINSIYET CINSIYET { get; set; }

        public string SonOkunanKitap 
        { 
            get
            {
                if (Kitaplar != null && Kitaplar.Count > 0)
                {
                    return Kitaplar.Last();
                }

                else
                {
                    return null;
                }
            }
        }
        public float Ortalama
        {
            get
            {
                if (Notlar.Count == 0)
                {
                    return 0;
                }
                return (float)Notlar.Average(x => x.Not);
            }
        }
        public Adres Adresi { get; set; }

        public List<string> Kitaplar = new List<string>();

        public List<DersNotu> Notlar = new List<DersNotu>();


    }

    public enum SUBE
    {
        Empty , A , B , C
    }

    public enum CINSIYET
    {
        Empty , Kiz , Erkek
    }



}
