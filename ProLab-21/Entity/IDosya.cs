using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab_21.Entity
{
    class IDosya
    {
        public static  string baslangicYolu = Application.StartupPath;
        public static string path = baslangicYolu + "/assets/";

        public string konumDosyaYolu = path+ "konum.png";
        public string haritaDosyaYolu = path+"harita.jpg";
        public string sehirlerDosyaYolu = path + "sehir.txt";
        public string kordinatDosyaYolu = path + "kordinat.txt";
    }
}
