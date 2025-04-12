using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okulyönetimuygulaması // Okul ile ilgili verilerle işlemler burada
{

    internal class Okul
    {

        static Ogrenci O = new Ogrenci();
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        // kurucu metot olabilir

        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumTarihi, CINSIYET Cinsiyet, SUBE Sube)
        {
            while (Ogrenciler.Any(o => o.No == no))
            {
                no++;
                Console.WriteLine("Sistemde" + (no - 1) + " numaralı öğrenci olduğu için öğrenci no " + no + " olarak değiştirildi.");
            }

            Ogrenci o = new Ogrenci();
            o.Ad = ad;
            o.Soyad = soyad;
            o.CINSIYET = Cinsiyet;
            o.DogumTarihi = dogumTarihi;
            o.No = no;
            o.SUBE = Sube;

            this.Ogrenciler.Add(o);
        }
        public bool OgrenciSil(int ogrenciNo)
        {
            Ogrenci ogrenci = Ogrenciler.FirstOrDefault(o => o.No == ogrenciNo);

            if (ogrenci == null)
            {

                return false;

            }

            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.SUBE);
            Console.Write("Öğrenciyi silmek istediğinize emin misiniz (E/H) : ");
            string secim = Console.ReadLine().ToUpper(); 

            if (secim == "E")
            {
                 Ogrenciler.Remove(ogrenci);
                 Console.WriteLine("Öğrenci başarılı bir şekilde silindi.");
            }
            else
            {
                Console.WriteLine("Öğrenci silinmedi.");
            }
            return true;
        }
        public void NotEkle(int no, string ders, int not)
        {
            Ogrenci o = this.Ogrenciler.Where(x => x.No == no).FirstOrDefault();

            if (o != null)
            {
                DersNotu ds = new DersNotu(ders, not);
                o.Notlar.Add(ds);
            }

        }
        public void ButunOgrencileriListele()
        {
            List<Ogrenci> BOgrenciler = Ogrenciler.OrderBy(o => o.No).ThenBy(o => o.No).ToList();

            foreach (Ogrenci item in BOgrenciler)
            {

                Console.WriteLine(item.SUBE.ToString().PadRight(13) + item.No.ToString().PadRight(6) + item.Ad.PadRight(7) + item.Soyad.PadRight(21)
                    + item.Ortalama.ToString().PadRight(20) + item.Kitaplar.Count);
            }

        }
        public void IllereOgrencileriListele()
        {
            List<Ogrenci> SOgrenciler = Ogrenciler.OrderBy(o => o.Adresi?.Il ?? "").ThenBy(o => o.No).ToList();

            foreach (Ogrenci item in SOgrenciler)
            {
                string il = item.Adresi?.Il ?? "Adresi Yok";
                string ilce = item.Adresi?.Ilce ?? "Adresi Yok";
                string mahalle = item.Adresi?.Mahalle ?? "Adresi Yok";
                Console.WriteLine(item.SUBE.ToString().PadRight(10) + item.No.ToString().PadRight(10) + item.Ad.PadRight(7) + item.Soyad.PadRight(13)
                    + il.PadRight(15) + ilce.PadRight(15) + mahalle);
            }

        }
        public bool OgrencininKitaplariListele(int ogrenciNo)
        {
            Ogrenci ogrenci = Ogrenciler.FirstOrDefault(o => o.No == ogrenciNo);

            if (ogrenci == null)
            {

                return false;

            }

            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.SUBE);
            Console.WriteLine("Okudugu   Kitaplar");
            Console.WriteLine("----------------------");

            foreach (string item in ogrenci.Kitaplar)
            {
                Console.WriteLine(item);
            }
            return true;
        }
        public bool OgrenciNotlariniGoruntule(int ogrenciNo)
        {
            Ogrenci ogrenci = Ogrenciler.FirstOrDefault(o => o.No == ogrenciNo);


            if (ogrenci == null)
            {

                return false;

            }

            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.SUBE);
            Console.WriteLine("Dersin Adı     Notu");
            Console.WriteLine("----------------------");

            foreach (DersNotu not in ogrenci.Notlar)
            {
                Console.WriteLine(not.DersAdi.PadRight(15) + not.Not);
            }
            return true;
        }
        public void ListeYazdir(List<Ogrenci> liste)
        {
            foreach (Ogrenci item in liste) 
            {
                Console.WriteLine(item.SUBE.ToString().PadRight(13) + item.No.ToString().PadRight(6) + item.Ad.PadRight(7) + item.Soyad.PadRight(20)
                    + item.Ortalama.ToString().PadRight(20) + item.Kitaplar.Count);
            }
        }
        public void SubeyeGöreListe(string sube) 
        {
            List<Ogrenci> SubeyeGöreListe = Ogrenciler.Where(o => o.SUBE.ToString() == sube).ToList();
            ListeYazdir(SubeyeGöreListe);

        }
        public void CinsiyeteGöreListe(string cinsiyet)
        {
            List<Ogrenci> CinsiyetListe = Ogrenciler.Where(o => o.CINSIYET.ToString() == cinsiyet).ToList();
            ListeYazdir(CinsiyetListe);

        }
        public void DogumTarihineGoreListele(DateTime tarih)
        {
            List<Ogrenci> DogumTarihineGoreListe = Ogrenciler.Where(o => o.DogumTarihi > tarih).OrderBy(o => o.DogumTarihi).ToList();
            ListeYazdir(DogumTarihineGoreListe);
        }
        public void EnYuksetNotluBesKisi()
        {
            List<Ogrenci> EnYuksekOgrenciListele = Ogrenciler.OrderByDescending(o => o.Ortalama).Take(5).ToList();
            ListeYazdir(EnYuksekOgrenciListele);

        }
        public void EnDusukNotluUcKisi()
        {
            List<Ogrenci> EnDusukUcOgrenciListele = Ogrenciler.OrderBy(o => o.Ortalama).Take(3).ToList();
            ListeYazdir(EnDusukUcOgrenciListele);

        }
        public bool OgrencininNotOrtalaması(int ogrenciNo)
        {
            Ogrenci ogrenci = Ogrenciler.FirstOrDefault(o => o.No == ogrenciNo);

            if (ogrenci == null)
            {

                return false;

            }

            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.SUBE);
            Console.Write("Öğrencinin Not Ortalaması : " + ogrenci.Ortalama);
           return true;
        }
        public bool OgrencininOkuduğuSonKitap(int ogrenciNo)
        {
            Ogrenci ogrenci = Ogrenciler.FirstOrDefault(o => o.No == ogrenciNo);
            
            if (ogrenci == null)
            {
                
                return false;

            }
            
            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.SUBE);
            Console.Write("Öğrencinin Okuduğu Son Kitap : " + ogrenci.SonOkunanKitap);
             return true;
        }
        public bool OgrenciNumarasiKontrol(int no, out Ogrenci ogrenci)
        {
            ogrenci = Ogrenciler.FirstOrDefault(o => o.No == no);
            return ogrenci != null;
        }
        public bool OgrenciniOkuduguKitabıGir(int ogrenciNo)
        {
            Ogrenci ogrenci = Ogrenciler.FirstOrDefault(o => o.No == ogrenciNo);
            if (ogrenci == null)
            {

                return false;

            }
            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.SUBE);
            Console.WriteLine();

            Console.Write("Eklenecek Kitabın Adı : ");
            string kitap = Console.ReadLine();

            ogrenci.Kitaplar.Add(kitap);
            return true;


        }
        public Ogrenci OgrenciBul(int no)
        {
            return Ogrenciler.FirstOrDefault(o => o.No == no);
        }
        public bool OgrencininAdresiniGir(int ogrenciNo)
        {
            Ogrenci ogrenci = Ogrenciler.FirstOrDefault(o => o.No==ogrenciNo);
            if(ogrenci == null)
            {
                return false;
            }
            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogrenci.SUBE);
            Console.WriteLine();

            Console.Write("Il : " );
            string il = Console.ReadLine().ToUpper();
            Console.Write("Ilce : ");
            string ilce = Console.ReadLine().ToUpper();
            Console.Write("Mahalle : ");
            string mahalle = Console.ReadLine().ToUpper();
            ogrenci.Adresi = new Adres
            {
                Il = il,
                Ilce = ilce,
                Mahalle = mahalle,
            };
            return true;
        }
        public void SubedekiEnBasariliBesOgrenci(string sube)
        {
            List<Ogrenci> SubeyeGöreListe = Ogrenciler.Where(o => o.SUBE.ToString() == sube).OrderByDescending(o => o.Ortalama).Take(5).ToList();
            
            if (SubeyeGöreListe.Count == 0)
            {
                Console.WriteLine("Şube için kayıtlı öğrenci bulunamadı.");
            }
            else
            {
                ListeYazdir(SubeyeGöreListe);
            }
        }
        public void SubedekiEnDusukNotluUcOgrenci(string sube)
        {
            List<Ogrenci> SubeyeGoreListele = Ogrenciler.Where(o => o.SUBE.ToString() == sube).OrderBy(o =>o.Ortalama).Take(3).ToList();

            if (SubeyeGoreListele.Count == 0)
            {
                Console.WriteLine("Şube için kayıtlı öğrenci bulunamadı.");
            } 

            else
            {
                ListeYazdir(SubeyeGoreListele);
            }
        }
        public void SubeninOrtalaması(string sube)
        {
            List<Ogrenci> ortalamayaGoreOgrenciler = Ogrenciler.Where(o => o.SUBE.ToString() == sube).ToList();

            if (ortalamayaGoreOgrenciler.Count == 0)
            {
                Console.WriteLine("Şubede kayıtlı öğrenci bulunamadı.");
                return;
            }

            double toplamNot = 0;
            foreach(Ogrenci item in ortalamayaGoreOgrenciler)
            {
                toplamNot += item.Ortalama;
            }

            int ogrenciSayisi = ortalamayaGoreOgrenciler.Count;
            double ortalamaNot = toplamNot / ogrenciSayisi;

            Console.WriteLine(sube + " Şubesinin Not Ortalaması : " + ortalamaNot);

        }
        public bool OgrenciGuncelle(int ogrenciNo)
        {
            Ogrenci ogrenciGuncelle = Ogrenciler.FirstOrDefault(o => o.No == ogrenciNo);
            if (ogrenciGuncelle == null)
            {

                return false;

            }

            Console.WriteLine("Öğrencinin Adı Soyadı : " + ogrenciGuncelle.Ad + " " + ogrenciGuncelle.Soyad);
            Console.WriteLine("Öğrencinin Şubesi : " + ogrenciGuncelle.SUBE);
            Console.WriteLine();

            Console.Write("Öğrencinin Adı : ");
            ogrenciGuncelle.Ad = Console.ReadLine();

            Console.Write("Öğrencinin Soyadı : ");
            ogrenciGuncelle.Soyad = Console.ReadLine();

            Console.Write("Ögrencinin Dogum Tarihi (dd-mm-yyyy) : ");
            ogrenciGuncelle.DogumTarihi = DateTime.Parse(Console.ReadLine());

            while(true)
            {
                Console.Write("Öğrencinin Cinsiyeti (Kiz/Erkek) : ");
                string cinsiyet;
                cinsiyet = Console.ReadLine();
                cinsiyet = char.ToUpper(cinsiyet[0]) + cinsiyet.Substring(1).ToLower();

                if (cinsiyet == "Kiz" ||  cinsiyet == "Erkek")
                {
                    ogrenciGuncelle.CINSIYET = (CINSIYET)Enum.Parse(typeof(CINSIYET), cinsiyet);
                    break;
                     
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı.Tekrar deneyin.");
                }
            }
            while (true)
            {
                Console.Write("Öğrencinin Şubsesi (A/B/C) : ");
                string sube = Console.ReadLine().ToUpper();

                if (sube == "A" || sube == "B" || sube == "C")
                {
                    ogrenciGuncelle.SUBE = (SUBE)Enum.Parse(typeof(SUBE),sube); 
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı Giriş yapıldı. Tekrar deneyin.");
                }
            }
            return true;
        }


       

    }
}


