using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab_21.Entity
{
    class DDosya
    {
        public static  string baslangicYolu = Application.StartupPath;
        public static string path = baslangicYolu + "/assets/";
        public static string ciktilar = baslangicYolu + "/outputs/";
        public string konumDosyaYolu = path+ "konum.png";
        public string haritaDosyaYolu = path+"harita.jpg";
        public string sehirlerDosyaYolu = path + "sehir.txt";
        public string kordinatDosyaYolu = path + "kordinat.txt";
        public string ciktiDosyaYolu = ciktilar +
            DateTime.Now.Year.ToString() + "-" +
            DateTime.Now.Month.ToString() + "-" +
            DateTime.Now.Day.ToString() + "-" +
            DateTime.Now.Hour.ToString()+"-"+
            DateTime.Now.Minute.ToString() +"-"+
            DateTime.Now.Second.ToString() +
            ".txt";
   
    public DDosya()
        {
            Directory.CreateDirectory(baslangicYolu+"/Outputs");
        }
    }
}
