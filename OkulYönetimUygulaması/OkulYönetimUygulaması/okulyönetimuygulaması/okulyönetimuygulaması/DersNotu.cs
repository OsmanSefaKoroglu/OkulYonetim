using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okulyönetimuygulaması
{
    internal class DersNotu
    {

        public string DersAdi;
        public int Not;


        //ctor kurucu metot kurma kısa yolu
        public DersNotu(string dersAdi, int not)
        {
            this.DersAdi = dersAdi;
            this.Not = not;

        }

    }
}
