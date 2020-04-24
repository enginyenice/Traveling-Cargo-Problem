using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_21.Entity
{
    class DSehir
    {
        public int plaka;
        public int kordinatX;
        public int kordinatY;
        public string sehirAdi;
        public int komsuSayisi;
        public DSehir[] komsular = new DSehir[100];
        public int[] komsuMesafe = new int[100];
        public DSehir ileri;
        public DSehir(int plaka, string sehirAdi)
        {
            this.plaka = plaka;
            this.sehirAdi = sehirAdi;
            this.komsuSayisi = 0;
        }
    }
}