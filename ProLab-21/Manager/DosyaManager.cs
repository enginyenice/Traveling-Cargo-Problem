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
        IDosya Dosya = new IDosya();
        //SehirManager sehirManager = new SehirManager();
        public void sehirListesiAl(SehirManager sehirManager)
        {

            string dosya_yolu = @Dosya.DosyaYolu;
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
            string dosya_yolu = @Dosya.DosyaYolu;
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
            string dosya_yolu = @Dosya.KordinatDosyaYolu;
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
    }
}
