using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace okulyönetimuygulaması
{
    internal class Program
    {
        static Okul Okul = new Okul();
        static void Main(string[] args)
        {
            SahteVeriEkle();
            Uygulama();

        }


        static void Uygulama()
        {

            Menu();


            string secim = SecimAl();

            switch (secim)
            {

                case "1":
                    ButunOgrencileriListele();
                    break;
                case "2":
                    SubeyeGöreListele();
                    break;
                case "3":
                    CinsiyeteGoreListele();
                    break;
                case "4":
                    DogumTarihineGoreListele();
                    break;
                case "5":
                    IllereGoreListele();
                    break;
                case "6":
                    OgrenciNotlariniGoruntule(); // tekrar tekrar numara almayı entegre ettim
                    break;
                case "7":
                    OgrencininOkuduguKitaplariListele(); // tekrar tekrar numara almayı entegre ettim
                    break;
                case "8":
                    EnYuksekNotluBesOgrenci();
                    break;
                case "9":
                    EnDusukNotluUcOgrenci();
                    break;
                case "10":
                    SubedekiEnBasariliBesOgrenci(); // tekrar tekrar Şube almayı entegre ettim
                    break;
                case "11":
                    SubedekiEnDusukNotluUcOgrenci(); // tekrar tekrar Şube almayı entegre ettim
                    break;
                case "12":
                    OgrencininNotOrtalaması(); // tekrar tekrar numara almayı entegre ettim
                    break;
                case "13":
                    SubeninNotOrtalaması();
                    break;
                case "14":
                    OgrencininSonOkuduguKitap(); // tekrar tekrar numara almayı entegre ettim
                    break;
                case "15":
                    OgrenciEkle();
                    break;
                case "16":
                    OgrenciGuncelle();
                    break;
                case "17":
                    OgrenciSil();  // tekrar tekrar numara almayı entegre ettim
                    break;
                case "18":
                    OgrencininAdresiniGir(); // tekrar tekrar numara almayı entegre ettim
                    break;
                case "19":
                    OgrencininOkuduguSonKitap(); // tekrar tekrar numara almayı entegre ettim
                    break;
                case "20":
                    NotGir(); // tekrar tekrar numara almayı entegre ettim
                    break;
                case "çıkış":
                    Environment.Exit(0);
                    break;
               
            }
            Console.WriteLine();
        }

        static void OgrenciGuncelle()
        {
            Console.WriteLine("16-Öğrenci Güncelle ------------------------------------------");
            int ogrenciNo;

            while (true)
            {
                Console.Write("Öğrencinin numarası: ");
                string secim = Console.ReadLine();
                if (int.TryParse(secim, out ogrenciNo))
                {
                    if (Okul.OgrenciGuncelle(ogrenciNo))
                    {
                        Console.WriteLine("Öğrenci güncellendi.");
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Bu numarada bir öğrenci yok. Tekrar deneyin.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                }

                 
            }
            Console.WriteLine();
            SecimSonrasiSecim(); 
        }
        static void SubeninNotOrtalaması()
        {

            Console.WriteLine("13-Şubenin Not Ortalamasını Gör -----------------------------------------");
            string sube;

            while(true)
            {
                Console.Write("Bir şube seçin (A/B/C):");
                sube = Console.ReadLine().ToUpper();

                if (sube == "A" || sube == "B" || sube == "C")
                {
                    Okul.SubeninOrtalaması(sube);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin.");
                    Console.ResetColor();
                    continue;
                }
            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void SubedekiEnDusukNotluUcOgrenci()
        {
            Console.WriteLine("11- Şubedeki en düşük notlu 3 öğrenciyi listele --------------------------------");
            string sube;

            while(true)
            {
                Console.Write("Listelemek istediğiniz Şubeyi girin (A/B/C) : ");
                sube = Console.ReadLine().ToUpper();

                if (sube == "A" || sube == "B" || sube == "C")
                {
                    Okul.SubedekiEnDusukNotluUcOgrenci(sube);
                    break;
                } 
                else
                {
                    Console.WriteLine("Geçersiz şube. Tekrar deneyin.");
                }
            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void SubedekiEnBasariliBesOgrenci()
        {

            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");
            string sube;

            while (true)
            {
                Console.Write("Listelemek istediğiniz Şubeyi girin (A/B/C) : ");
                sube = Console.ReadLine().ToUpper();

                if (sube =="A" ||  sube =="B" || sube =="C")
                {
                    Okul.SubedekiEnBasariliBesOgrenci(sube);
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz Şube. Tekrar deneyin.");
                }
            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void OgrencininAdresiniGir()
        {
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");
            int ogrenciNo;

            while (true)
            {
                Console.Write("Öğrencinin numarası : ");
                string secim = Console.ReadLine();
                if (int.TryParse(secim ,out ogrenciNo))
                {
                    
                    if (Okul.OgrencininAdresiniGir(ogrenciNo))
                    {
                        Console.WriteLine("Bilgiler sisteme girilmiştir.");
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.\r\n");
                        Console.ResetColor();
                    }

                }

                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                    return;
                }
            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void OgrencininOkuduguSonKitap()
        {
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");
            int ogrenciNo;
            while (true)
            {
                Console.Write("Öğrencinin numarası : ");
                string secim = Console.ReadLine();

                if(int.TryParse(secim, out ogrenciNo))
                {
                    if(Okul.OgrenciniOkuduguKitabıGir(ogrenciNo)) 
                    {
                        Console.WriteLine("Bilgiler Sisteme Yüklenmiştir.");
                        break;
                    }
                    else
                    {
                      Console.WriteLine("Bu numarada bir öğrenci yok. Tekrar deneyin");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                    return;
                }
            }
            Console.WriteLine();
            SecimSonrasiSecim();

        }
        static void OgrenciSil()
        {
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");
            int ogrenciNo;
            while (true)
            {
                Console.Write("Öğrencinin numarası : ");
                string secim = Console.ReadLine();
                if(int.TryParse(secim, out ogrenciNo))
                {
                    if (Okul.OgrenciSil(ogrenciNo))
                    {
                        break;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.\r\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                }
            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void OgrenciEkle()
        {
            Console.WriteLine("15 - Öğrenci Ekle----------------------------------------------------");
            Console.Write("Ögrencinin numarası : ");
            if (!int.TryParse(Console.ReadLine(), out int no))
            {
                Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                return;
            }
            Console.Write("Ögrencinin adı : ");
            string isim = Console.ReadLine();
            isim = char.ToUpper(isim[0]) + isim.Substring(1).ToLower();
            Console.Write("Ögrencinin soyadı : ");
            string soyad = Console.ReadLine();
            soyad = char.ToUpper(soyad[0]) + soyad.Substring(1).ToLower();

            Console.Write("Öğrencinin doğum tarihi (gg.aa.yyyy) : ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dogumTarihi))
            {
                Console.WriteLine("Geçersiz tarih formatı. Tekrar deneyin.");
                return;
            }
            Console.Write("Ögrencinin cinsiyeti( Kiz / Erkek ) : ");
            string cinsiyetInput = Console.ReadLine();
            cinsiyetInput = char.ToUpper(cinsiyetInput[0]) + cinsiyetInput.Substring(1);

            if (!Enum.TryParse(cinsiyetInput,out CINSIYET cinsiyet))
            {
                Console.WriteLine("Geçersiz cinsiyet. Tekrar deneyin.");
                return;
            }
            Console.Write("Ögrencinin subesi( A / B / C ) : ");
            string subeInput = Console.ReadLine().ToUpper();

            if (!Enum.TryParse(subeInput, out SUBE sube))
            {
                Console.WriteLine("Geçersiz şube. Tekrar deneyin.");
                return;
            }
            Okul.OgrenciEkle(no, isim, soyad,dogumTarihi, cinsiyet,sube);
            SecimSonrasiSecim();
        }
        static void OgrencininSonOkuduguKitap()
        {
            Console.WriteLine("13 - Öğrencinin Son Okuduğu Kitabı Gör --------------------------------------------------");
            int ogrenciNo;

            while (true)
            {
                Console.Write("Öğrencinin numarası: ");
                string secim = Console.ReadLine();
                if (int.TryParse(secim, out ogrenciNo))
                {
                    if(Okul.OgrencininOkuduğuSonKitap(ogrenciNo))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.\r\n");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                    return;
                }
                
            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void OgrencininNotOrtalaması()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");
            int ogrenciNo;

            while (true)
            {
                Console.Write("Öğrencinin numarası: ");
                string secim = Console.ReadLine();
                if (int.TryParse(secim, out ogrenciNo))
                {
                    if (Okul.OgrencininNotOrtalaması(ogrenciNo))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                    return;
                }

            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void EnDusukNotluUcOgrenci()
        {
            Console.WriteLine("1 - Okuldaki En Düşük Notlu Üç Öğrenci --------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Şube         No     Adı Soyadı                Not Ort.       Okudugu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Console.WriteLine(" ");
            Okul.EnDusukNotluUcKisi();
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void EnYuksekNotluBesOgrenci()
        {
            Console.WriteLine("1 - Okuldaki En Yüksek Notlu Beş Öğrenci --------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Şube         No     Adı Soyadı                Not Ort.       Okudugu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Console.WriteLine(" ");
            Okul.EnYuksetNotluBesKisi();
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void OgrencininOkuduguKitaplariListele()
        {
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele --------------------------------------------------");
            int ogrenciNo;

            while (true)
            {
                Console.Write("Öğrencinin numarası: ");
                string secim = Console.ReadLine();
                if (int.TryParse(secim, out ogrenciNo))
                {
                    if (Okul.OgrencininKitaplariListele(ogrenciNo))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                    return;
                }

            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void OgrenciNotlariniGoruntule()
        {
            Console.WriteLine("6 - Öğrencinin notlarını görüntüle --------------------------------------------------");
            int ogrenciNo;

            while (true)
            {
                Console.Write("Öğrencinin numarası: ");
                string secim = Console.ReadLine();
                if (int.TryParse(secim, out ogrenciNo))
                {
                    if (Okul.OgrenciNotlariniGoruntule(ogrenciNo))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bu numarada bir öğrenci yok. Tekrar deneyin.");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
                    return;
                }

            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void IllereGoreListele()
        {
            Console.WriteLine("1 - İllere Göre Öğrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sube      No        Adı Soyadı           Sehir          İlçe          Mahalle");
            Console.WriteLine("".PadRight(80, '-'));
            Okul.IllereOgrencileriListele();
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void CinsiyeteGoreListele()
        {
            Console.WriteLine("1 - Cinsiyete Göre Öğrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            Console.Write("Listelemek istediğiniz Cinsiyeti seçiniz : ");
            string cinsiyet = Console.ReadLine();
            cinsiyet = ilkHarfiBuyut(cinsiyet);

            Console.WriteLine("Şube         No     Adı Soyadı              Not Ort.     Okudugu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));

            Okul.CinsiyeteGöreListe(cinsiyet);

            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void ButunOgrencileriListele()
        {
            Console.WriteLine("1 - Bütün Öğrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Şube         No     Adı Soyadı              Not Ort.     Okudugu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Okul.ButunOgrencileriListele();
            Console.WriteLine();

            SecimSonrasiSecim();
        }
        static void SubeyeGöreListele()
        {

            Console.WriteLine(" 2 - Şubeye Göre Öğrencileri Listele--------------------------------------------");
            Console.Write(" Listelemek istediğiniz şubeyi girin(A / B / C): ");
            string sube = Console.ReadLine().ToUpper();


            Console.WriteLine("");
            Console.WriteLine("Şube         No     Adı Soyadı                Not Ort.       Okudugu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));

            Okul.SubeyeGöreListe(sube);
            Console.WriteLine(" ");
            SecimSonrasiSecim();
        }
        static void DogumTarihineGoreListele()
        {
            Console.WriteLine("4 - Doğum Tarihine Göre Öğrencileri Listele --------------------------------------------------");
            Console.Write("Hangi tarihten sonraki öğrencileri listelemek istersiniz (gg.aa.yyyy): ");
            string tarih = Console.ReadLine();

            if (DateTime.TryParse(tarih, out DateTime date))
            {
                Console.WriteLine("");
                Console.WriteLine("Şube         No     Adı Soyadı                Not Ort.       Okudugu Kitap Say.");
                Console.WriteLine("".PadRight(80, '-'));

                Okul.DogumTarihineGoreListele(date);
            }
            else
            {
                Console.WriteLine("Geçersiz tarih formatı tekrar deneyin.");
            }
            Console.WriteLine(" ");
            SecimSonrasiSecim();

        }
        static string SecimAl()
        {
            int denemeSayisi = 0;
            List<string> gecerliSecimler = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "çıkış", "liste" };

            while (denemeSayisi < 10)
            {
                Console.Write("Yapmak istediğiniz işlemi seçiniz : ");
                string secim1 = Console.ReadLine().ToLower();


                if (gecerliSecimler.Contains(secim1))
                {
                    return secim1;
                }

                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }
                denemeSayisi++;
            }

            Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
            Environment.Exit(0);
            return null;
        }
        static void Menu()
        {
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");

            Console.WriteLine("Çıkış yapmak için “çıkış” yazıp “enter”a basın.");

         

        }
        static void NotGir()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Not Gir -------------------------------------------------------");
                    Console.Write("Ogrencinin Numarası : ");
                    int no = int.Parse(Console.ReadLine());

                    Ogrenci ogrenci = Okul.OgrenciBul(no);
                    if (ogrenci == null)
                    {
                        Console.WriteLine("Bu numarada bir öğrenci yok. Tekrar deneyin.");
                        continue;
                    }

                    Console.WriteLine("Öğrencinin Adı Soyadı : " + ogrenci.Ad + " " + ogrenci.Soyad);
                    Console.WriteLine("Öğrencinin şubesi : " + ogrenci.SUBE);

                    Console.Write("Ders : ");
                    string ders = Console.ReadLine();
                    Console.Write("Adet : ");
                    int adet = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= adet; i++)
                    {
                        Console.Write(i + " . Notu girin : ");
                        int not = int.Parse(Console.ReadLine());

                        Okul.NotEkle(no, ders, not);
                    }

                    Console.WriteLine("Bilgiler sisteme girilmiştir.");
                    break;

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }
            }
            Console.WriteLine();
            SecimSonrasiSecim();
        }
        static void SahteVeriEkle()
        {

            Okul.OgrenciEkle(1, "Ali", "Yılmaz", new DateTime(2003, 5, 4), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(2, "Şerife", "Alp", new DateTime(2008, 6, 14), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(3, "Elif", "Selçuk", new DateTime(2005, 1, 1), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(4, "Betül", "Yılmaz", new DateTime(1999, 2, 2), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(5, "Aleyna", "Aslan", new DateTime(2001, 3, 6), CINSIYET.Kiz, SUBE.C);
            Okul.OgrenciEkle(6, "Faruk", "Kalın", new DateTime(2008, 3, 6), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(7, "Eslem",  "Dolu", new DateTime(2005, 3, 6), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(8, "Nazlı", "Bal", new DateTime(2004, 3, 6), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(9, "Akın", "Kaçar", new DateTime(2003, 3, 6), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(10, "Aslı", "Göker", new DateTime(2002, 3, 6), CINSIYET.Kiz, SUBE.C);
            Okul.OgrenciEkle(11, "Ekrem", "Aktaş", new DateTime(2003, 5, 7), CINSIYET.Erkek, SUBE.A);

            Ogrenci ogr1 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 1);
            ogr1?.Kitaplar.Add("SEFİLLER");
            ogr1?.Kitaplar.Add("KUYUCAKLI YUSUF");
            Ogrenci ogr2 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 2);
            ogr2?.Kitaplar.Add("OBLOMOV");
            ogr2?.Kitaplar.Add("AYLAK ADAM");
            Ogrenci ogr3 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 3);
            ogr3?.Kitaplar.Add("TUTUNAMAYANLAR");
            ogr3?.Kitaplar.Add("TEHLİKELİ OYUNLAR");
            Ogrenci ogr4 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 4);
            ogr4?.Kitaplar.Add("SUÇ VE CEZA");
            ogr4?.Kitaplar.Add("COSMOS");
            Ogrenci ogr5 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 5);
            ogr5?.Kitaplar.Add("Zorba");
            ogr5?.Kitaplar.Add("1984");
            Ogrenci ogr6 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 6);
            ogr6?.Kitaplar.Add("ÜTOPYA");
            ogr6?.Kitaplar.Add("SİLMARİLLİON");
            Ogrenci ogr7 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 7);
            ogr7?.Kitaplar.Add("SİMYACI");
            ogr7?.Kitaplar.Add("HAC");
            Ogrenci ogr8 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 8);
            ogr8?.Kitaplar.Add("DÜŞÜŞ");
            ogr8?.Kitaplar.Add("YALNIZLIK");
            ogr8?.Kitaplar.Add("MUTLU ÖLÜM");
            Ogrenci ogr9 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 9);
            ogr9?.Kitaplar.Add("BEYAZ GEMİ");
            ogr9?.Kitaplar.Add("1984");
            Ogrenci ogr10 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 10);
            ogr10?.Kitaplar.Add("DORİAN GRAY'İN PORTRESİ");
            ogr10?.Kitaplar.Add("VAR MISIN");
            Ogrenci ogr11 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 11);
            ogr11?.Kitaplar.Add("İnsan İnsana");
            ogr11?.Kitaplar.Add("Kürk Mantolu Madonna");


            Okul.NotEkle(1, "Matematik", 50);
            Okul.NotEkle(1, "Matematik", 75);
            Okul.NotEkle(1, "Türkçe", 35);
            Okul.NotEkle(1, "Türkçe", 76);
            Okul.NotEkle(2, "Matematik", 60);
            Okul.NotEkle(2, "Kimya", 70);
            Okul.NotEkle(2, "Türkçe", 80);
            Okul.NotEkle(3, "Matematik", 90);
            Okul.NotEkle(3, "Fizik", 84);
            Okul.NotEkle(4, "Kimya", 57);
            Okul.NotEkle(4, "Matematik", 59);
            Okul.NotEkle(4, "Türkçe", 68);
            Okul.NotEkle(5, "Türkçe", 78);
            Okul.NotEkle(5, "Matematik", 54);
            Okul.NotEkle(5, "Kimya", 58);
            Okul.NotEkle(6, "Türkçe", 70);
            Okul.NotEkle(6, "Matematik", 57);
            Okul.NotEkle(6, "Kimya", 57);
            Okul.NotEkle(7, "Türkçe", 79);
            Okul.NotEkle(7, "Matematik", 51);
            Okul.NotEkle(7, "Kimya", 68);
            Okul.NotEkle(8, "Türkçe", 88);
            Okul.NotEkle(8, "Matematik", 94);
            Okul.NotEkle(8, "Kimya",99);
            Okul.NotEkle(9, "Türkçe", 58);
            Okul.NotEkle(9, "Matematik",64);
            Okul.NotEkle(9, "Kimya", 88);
            Okul.NotEkle(10, "Türkçe",68);
            Okul.NotEkle(10, "Matematik",84);
            Okul.NotEkle(10, "Kimya",28);
            Okul.NotEkle(11, "Türkçe", 10);
            Okul.NotEkle(11, "Matematik", 10);
            Okul.NotEkle(11, "Kimya", 10);


            Ogrenci o1 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 1);
            o1.Adresi = new Adres { Il = "İSTANBUL", Ilce = "BEŞİKTAŞ", Mahalle = "XXXXX" };

            Ogrenci o2 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 2);
            o2.Adresi = new Adres { Il = "İZMİR", Ilce = "BORNOVA", Mahalle = "SAMAN" };

            Ogrenci o3 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 3);
            o3.Adresi = new Adres { Il = "Bursa", Ilce = "NİLÜFER", Mahalle = "SELİM" };

            Ogrenci o4 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 4);
            o4.Adresi = new Adres { Il = "AKSARAY", Ilce = "ESKİL", Mahalle = "ÇIKMAZ" };

            Ogrenci o5 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 5);
            o5.Adresi = new Adres { Il = "ANKARA", Ilce = "KIZILAY", Mahalle = "BÜYÜK" };

            Ogrenci o6 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 6);
            o6.Adresi = new Adres { Il = "KAYSERİ", Ilce = "MELİKGAZİ", Mahalle = "ŞİRİNTEPE" };

            Ogrenci o7 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 7);
            o7.Adresi = new Adres { Il = "İZMİR", Ilce = "ALİAĞA", Mahalle = "CUMHURİYET" };

            Ogrenci o8 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 8);
            o8.Adresi = new Adres { Il = "İSTANBUL", Ilce = "FATİH", Mahalle = "ATAŞ" };

            Ogrenci o9 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 9);
            o9.Adresi = new Adres { Il = "AKSARAY", Ilce = "SULTANHANI", Mahalle = "MEZARLIK" };

            Ogrenci o10 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 10);
            o10.Adresi = new Adres { Il = "IĞDIR", Ilce = "ARALIK", Mahalle = "HASANHAN" };

            Ogrenci o11 = Okul.Ogrenciler.FirstOrDefault(x => x.No == 11);
            o11.Adresi = new Adres { Il = "SAMSUN", Ilce = "TERME", Mahalle = "KÜÇÜK" };

        }
        static void SecimSonrasiSecim()
        {

            Console.WriteLine("Menüyü tekrar listelemek için 'liste', çıkış yapmak için 'çıkış' yazın.");
            Console.WriteLine();
            Console.Write("Yapmak istediğiniz işlemi seçin : ");
            string secim1 = Console.ReadLine().ToLower();

            if (secim1 == "liste")
            {
                Uygulama();
            }
            else if (secim1 == "çıkış")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Geçersiz işlem. Ana menüye dönülüyor...");
                Uygulama();
            }
        }
        public static string ilkHarfiBuyut(string giris)
        {
            return giris.Substring(0, 1).ToUpper() + giris.Substring(1).ToLower();

        }

    }
}
    
