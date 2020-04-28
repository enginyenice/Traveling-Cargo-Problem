using ProLab_21.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_21.Manager
{
    class DosyaManager
    {
        public DDosya Dosya = new DDosya();
        //SehirManager sehirManager = new SehirManager();
        public void sehirListesiAl(SehirManager sehirManager)
        {

            string dosya_yolu = @Dosya.sehirlerDosyaYolu;
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            char ayrac = ',';
            while (yazi != null)
            {
                string[] satir = yazi.Split(ayrac);
                yazi = sw.ReadLine();
                sehirManager.sehirEkle(Int32.Parse(satir[0]), satir[1]);

            }
            sw.Close();
            fs.Close();
        }
        public void komsuListesiAl(SehirManager sehirManager)
        {
            string dosya_yolu = @Dosya.sehirlerDosyaYolu;
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            char ayrac = ',';
            char ayrac2 = '-';
            while (yazi != null)
            {
                string[] satir = yazi.Split(ayrac);
                yazi = sw.ReadLine();

                for (int i = 2; i < satir.Length; i++)
                {
                    string[] komsuMesafeAyir = satir[i].Split(ayrac2);
                    //prm.ekle(Int32.Parse(satir[1]), komsuMesafeAyir[0], komsuMesafeAyir[1]);
                    sehirManager.komsuEkle(satir[1], komsuMesafeAyir[0], Int32.Parse(komsuMesafeAyir[1]));
                    
                }

            }
            sw.Close();
            fs.Close();
        }
        public void kordinatEkle(SehirManager sehirManager)
        {
            string dosya_yolu = Dosya.kordinatDosyaYolu;
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            char ayrac = ',';
            while (yazi != null)
            {
                string[] satir = yazi.Split(ayrac);
                sehirManager.kordinatEkle(Int32.Parse(satir[0]), Int32.Parse(satir[1]), Int32.Parse(satir[2]));
                yazi = sw.ReadLine();
                

            }
            sw.Close();
            fs.Close();
        }
        public void ciktiDosyasiOlustur(SehirManager sehirManager, List<Int32> arananListesiIndis,List<Int32> yol0, List<Int32> yol1, List<Int32> yol2, List<Int32> yol3, List<Int32> yol4, List<Int32> tumMesafeler)
        {
         string dosya_yolu = Dosya.ciktiDosyaYolu;
         FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
         StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Gidilmesi Gereken Şehirler");
            sw.Write("Kocaeli(41)");
            for (int i = 0; i < arananListesiIndis.Count; i++)
            {
                sw.Write(" - " + sehirManager.GetSehir(arananListesiIndis[i] + 1).sehirAdi.ToString()+"("+ sehirManager.GetSehir(arananListesiIndis[i] + 1).plaka.ToString() + ")");
            }
            sw.Write("- Kocaeli(41)");
            sw.WriteLine("\nEn Kısa Yollar");
            if (yol0.Count > 0)
         {
            sw.Write("Kocaeli");
            for (int i = 0;i< yol0.Count;i++)
            {
                    sw.Write(" - "+sehirManager.GetSehir(yol0[i] + 1).sehirAdi.ToString());
            }
                sw.WriteLine("\n----[TOPLAM MESAFE: " + tumMesafeler[0].ToString() + "]----");
         }


            if (yol1.Count > 0)
            {
                sw.Write("Kocaeli");
                for (int i = 0; i < yol1.Count; i++)
                {
                    sw.Write(" - " + sehirManager.GetSehir(yol1[i] + 1).sehirAdi.ToString());
                }
                sw.WriteLine("\n----[TOPLAM MESAFE: " + tumMesafeler[1].ToString() + "]----");
            }




            if (yol2.Count > 0)
            {
                sw.Write("Kocaeli");
                for (int i = 0; i < yol2.Count; i++)
                {
                    sw.Write(" - " + sehirManager.GetSehir(yol2[i] + 1).sehirAdi.ToString());
                }
                sw.WriteLine("\n----[TOPLAM MESAFE: " + tumMesafeler[2].ToString() + "]----");
            }



            if (yol3.Count > 0)
            {
                sw.Write("Kocaeli");
                for (int i = 0; i < yol3.Count; i++)
                {
                    sw.Write(" - " + sehirManager.GetSehir(yol3[i] + 1).sehirAdi.ToString());
                }
                sw.WriteLine("\n----[TOPLAM MESAFE: " + tumMesafeler[3].ToString() + "]----");
            }


            if (yol4.Count > 0)
            {
                sw.Write("Kocaeli");
                for (int i = 0; i < yol4.Count; i++)
                {
                    sw.Write(" - " + sehirManager.GetSehir(yol4[i] + 1).sehirAdi.ToString());
                }
                sw.WriteLine("\n----[TOPLAM MESAFE: " + tumMesafeler[4].ToString() + "]----");
            }
            sw.WriteLine("\n-------------------------------------------------------------------------------------\n");
            sw.Flush();
                sw.Close();
                fs.Close();
        }
    }
}
