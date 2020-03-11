using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProLab_21;
using ProLab_21.Entity;

namespace ProLab_21.Manager
{
    class YolBulucuManager
    {
        
        public int indexOnMin(int[] mesafeler,int komsuSayisi)
        {
            int minMes = Int32.MaxValue;
            int indis = Int32.MinValue;
            for (int i = 0; i< komsuSayisi;i++)
            {
                if (mesafeler[i] < minMes)
                {
                    minMes = mesafeler[i];
                    indis = i;
                }
            }
            
            
            return indis;
        }
        public void yolBul(ISehir baslangicSehri,ISehir bitisSehiri)
        {

            int mesafe = 0;
            List<Int32> ziyaretEdilenler = new List<int>();

            while(baslangicSehri != bitisSehiri)
            {
                ziyaretEdilenler.Add(baslangicSehri.plaka);
                int enKisaKomsuIndis = indexOnMin(baslangicSehri.komsuMesafe,baslangicSehri.komsuSayisi);

                mesafe += baslangicSehri.komsuMesafe[enKisaKomsuIndis];
                baslangicSehri = baslangicSehri.komsular[enKisaKomsuIndis];

            }
        }
        
    }
}
