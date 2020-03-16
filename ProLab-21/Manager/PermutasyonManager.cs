using ProLab_21.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_21.Manager
{

    class PermutasyonManager
    {
        public IYol ilk;
        public IYol son;
        public PermutasyonManager()
        {
           
        }
        public bool yolEkle(int[] yol)
        {
            try
            {
                IYol node = new IYol(yol);
                if (ilk == null)
                {
                    ilk = node;
                    ilk.ileri = null;
                    son = ilk;
                }
                else
                {
                    son.ileri = node;
                    node.ileri = null;
                    son = node;
                }
                return true;
            }
            catch
            {

                return false;
            }
        }
        public void yolListele()
        {
            IYol iter = ilk;
            while(iter != null)
            {
                
                for(int i = 0; i< iter.yol.Length;i++)
                {
                    Console.Write(iter.yol[i].ToString()+ " ");
                }
                iter = iter.ileri;
                Console.WriteLine();
            }
        }

        public void permustasyon2(int[] arananArray){
            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    if (arananArray[a] != arananArray[b])
                    {
                        yol= new int[arananArray.Length];
                        yol[0] = arananArray[a]; 
                        yol[1] = arananArray[b]; 
                        yolEkle(yol);
                        
                    }

            //yolListele();



        }
        public void permustasyon3(int[] arananArray) {

            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    for (int c = 0; c < arananArray.Length; c++)
                        if (arananArray[a] != arananArray[b] && arananArray[a] != arananArray[c] &&
                                                                arananArray[b] != arananArray[c])
                    {
                        yol = new int[arananArray.Length];
                        yol[0] = arananArray[a];
                        yol[1] = arananArray[b];
                        yol[2] = arananArray[c];
                        yolEkle(yol);

                    }

            //yolListele();


        }
        public void permustasyon4(int[] arananArray) {
            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    for (int c = 0; c < arananArray.Length; c++)
                            for (int d = 0; d < arananArray.Length; d++)
                            if (arananArray[a] != arananArray[b] && arananArray[a] != arananArray[c] && arananArray[a] != arananArray[d] &&
                                                                    arananArray[b] != arananArray[c] && arananArray[b] != arananArray[d] &&
                                                                                                        arananArray[c] != arananArray[d])
                        {
                            yol = new int[arananArray.Length];
                            yol[0] = arananArray[a];
                            yol[1] = arananArray[b];
                            yol[2] = arananArray[c];
                            yol[3] = arananArray[d];
                            yolEkle(yol);

                        }

            //yolListele();
        }
        public void permustasyon5(int[] arananArray) {
            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    for (int c = 0; c < arananArray.Length; c++)
                        for (int d = 0; d < arananArray.Length; d++)
                            for(int f = 0; f< arananArray.Length;f++)
                            if (arananArray[a] != arananArray[b] && arananArray[a] != arananArray[c] && arananArray[a] != arananArray[d] && arananArray[a] != arananArray[f] &&
                                                                    arananArray[b] != arananArray[c] && arananArray[b] != arananArray[d] && arananArray[b] != arananArray[f] &&
                                                                                                        arananArray[c] != arananArray[d] && arananArray[c] != arananArray[f] &&
                                                                                                                                            arananArray[d] != arananArray[f])
                            {
                                yol = new int[arananArray.Length];
                                yol[0] = arananArray[a];
                                yol[1] = arananArray[b];
                                yol[2] = arananArray[c];
                                yol[3] = arananArray[d];
                                yol[4] = arananArray[f];
                                    yolEkle(yol);

                            }

            //yolListele();
        }
        public void permustasyon6(int[] arananArray) {
            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    for (int c = 0; c < arananArray.Length; c++)
                        for (int d = 0; d < arananArray.Length; d++)
                            for (int f = 0; f < arananArray.Length; f++)
                                for (int g = 0; g < arananArray.Length; g++)
                                    if (arananArray[a] != arananArray[b] && arananArray[a] != arananArray[c] && arananArray[a] != arananArray[d] && arananArray[a] != arananArray[f] && arananArray[a] != arananArray[g] &&
                                                                        arananArray[b] != arananArray[c] && arananArray[b] != arananArray[d] && arananArray[b] != arananArray[f] && arananArray[b] != arananArray[g] &&
                                                                                                            arananArray[c] != arananArray[d] && arananArray[c] != arananArray[f] && arananArray[c] != arananArray[g] &&
                                                                                                                                                arananArray[d] != arananArray[f] && arananArray[d] != arananArray[g] &&
                                                                                                                                                                                    arananArray[f] != arananArray[g])
                                {
                                    yol = new int[arananArray.Length];
                                    yol[0] = arananArray[a];
                                    yol[1] = arananArray[b];
                                    yol[2] = arananArray[c];
                                    yol[3] = arananArray[d];
                                    yol[4] = arananArray[f];
                                    yol[5] = arananArray[g];
                                    yolEkle(yol);

                                }

            //yolListele();

        }
        public void permustasyon7(int[] arananArray) {

            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    for (int c = 0; c < arananArray.Length; c++)
                        for (int d = 0; d < arananArray.Length; d++)
                            for (int f = 0; f < arananArray.Length; f++)
                                for (int g = 0; g < arananArray.Length; g++)
                                    for (int h = 0; h < arananArray.Length; h++)
                                        if (arananArray[a] != arananArray[b] && arananArray[a] != arananArray[c] &&  arananArray[a] != arananArray[d] && arananArray[a] != arananArray[f] && arananArray[a] != arananArray[g] && arananArray[a] != arananArray[h] &&
                                                                                 arananArray[b] != arananArray[c] && arananArray[b] != arananArray[d] && arananArray[b] != arananArray[f] && arananArray[b] != arananArray[g] && arananArray[b] != arananArray[h] &&
                                                                                                                     arananArray[c] != arananArray[d] && arananArray[c] != arananArray[f] && arananArray[c] != arananArray[g] && arananArray[c] != arananArray[h] &&
                                                                                                                                                         arananArray[d] != arananArray[f] && arananArray[d] != arananArray[g] && arananArray[d] != arananArray[h] &&
                                                                                                                                                                                             arananArray[f] != arananArray[g] && arananArray[f] != arananArray[h] &&
                                                                                                                                                                                                                                 arananArray[g] != arananArray[h])
                                    {
                                        yol = new int[arananArray.Length];
                                        yol[0] = arananArray[a];
                                        yol[1] = arananArray[b];
                                        yol[2] = arananArray[c];
                                        yol[3] = arananArray[d];
                                        yol[4] = arananArray[f];
                                        yol[5] = arananArray[g];
                                        yol[6] = arananArray[h];
                                            yolEkle(yol);

                                    }

            //yolListele();
        }
        public void permustasyon8(int[] arananArray) {
            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    for (int c = 0; c < arananArray.Length; c++)
                        for (int d = 0; d < arananArray.Length; d++)
                            for (int f = 0; f < arananArray.Length; f++)
                                for (int g = 0; g < arananArray.Length; g++)
                                    for (int h = 0; h < arananArray.Length; h++)
                                        for (int i = 0; i < arananArray.Length; i++)
                                         if (arananArray[a] != arananArray[b] && arananArray[a] != arananArray[c] && arananArray[a] != arananArray[d] && arananArray[a] != arananArray[f] && arananArray[a] != arananArray[g] && arananArray[a] != arananArray[h] && arananArray[a] != arananArray[i] &&
                                                                                 arananArray[b] != arananArray[c] && arananArray[b] != arananArray[d] && arananArray[b] != arananArray[f] && arananArray[b] != arananArray[g] && arananArray[b] != arananArray[h] && arananArray[b] != arananArray[i] &&
                                                                                                                     arananArray[c] != arananArray[d] && arananArray[c] != arananArray[f] && arananArray[c] != arananArray[g] && arananArray[c] != arananArray[h] && arananArray[c] != arananArray[i] &&
                                                                                                                                                         arananArray[d] != arananArray[f] && arananArray[d] != arananArray[g] && arananArray[d] != arananArray[h] && arananArray[d] != arananArray[i] &&
                                                                                                                                                                                             arananArray[f] != arananArray[g] && arananArray[f] != arananArray[h] && arananArray[f] != arananArray[i] &&
                                                                                                                                                                                                                                 arananArray[g] != arananArray[h] && arananArray[g] != arananArray[i] &&
                                                                                                                                                                                                                                                                     arananArray[h] != arananArray[i]
                                                                                                                                                                                                                                 )
                                        {
                                            yol = new int[arananArray.Length];
                                            yol[0] = arananArray[a];
                                            yol[1] = arananArray[b];
                                            yol[2] = arananArray[c];
                                            yol[3] = arananArray[d];
                                            yol[4] = arananArray[f];
                                            yol[5] = arananArray[g];
                                            yol[6] = arananArray[h];
                                            yol[7] = arananArray[i];
                                                yolEkle(yol);

                                        }

            //yolListele();


        }
        public void permustasyon9(int[] arananArray) {
            ilk = null;
            son = ilk;
            int[] yol;
            for (int a = 0; a < arananArray.Length; a++)
                for (int b = 0; b < arananArray.Length; b++)
                    for (int c = 0; c < arananArray.Length; c++)
                        for (int d = 0; d < arananArray.Length; d++)
                            for (int f = 0; f < arananArray.Length; f++)
                                for (int g = 0; g < arananArray.Length; g++)
                                    for (int h = 0; h < arananArray.Length; h++)
                                        for (int i = 0; i < arananArray.Length; i++)
                                            for (int j = 0; j < arananArray.Length; j++)
                                                if (arananArray[a] != arananArray[b] && arananArray[a] != arananArray[c] && arananArray[a] != arananArray[d] && arananArray[a] != arananArray[f] && arananArray[a] != arananArray[g] && arananArray[a] != arananArray[h] && arananArray[a] != arananArray[i] && arananArray[a] != arananArray[j] &&
                                                                                        arananArray[b] != arananArray[c] && arananArray[b] != arananArray[d] && arananArray[b] != arananArray[f] && arananArray[b] != arananArray[g] && arananArray[b] != arananArray[h] && arananArray[b] != arananArray[i] && arananArray[b] != arananArray[j] &&
                                                                                                                            arananArray[c] != arananArray[d] && arananArray[c] != arananArray[f] && arananArray[c] != arananArray[g] && arananArray[c] != arananArray[h] && arananArray[c] != arananArray[i] && arananArray[c] != arananArray[j] &&
                                                                                                                                                                arananArray[d] != arananArray[f] && arananArray[d] != arananArray[g] && arananArray[d] != arananArray[h] && arananArray[d] != arananArray[i] && arananArray[d] != arananArray[j] &&
                                                                                                                                                                                                    arananArray[f] != arananArray[g] && arananArray[f] != arananArray[h] && arananArray[f] != arananArray[i] && arananArray[f] != arananArray[j] &&
                                                                                                                                                                                                                                        arananArray[g] != arananArray[h] && arananArray[g] != arananArray[i] && arananArray[g] != arananArray[j] &&
                                                                                                                                                                                                                                                                            arananArray[h] != arananArray[i] && arananArray[h] != arananArray[j] &&
                                                                                                                                                                                                                                                                                                                arananArray[i] != arananArray[j] 
                                                                                                                                                                                                                                    )
                                            {
                                                yol = new int[arananArray.Length];
                                                yol[0] = arananArray[a];
                                                yol[1] = arananArray[b];
                                                yol[2] = arananArray[c];
                                                yol[3] = arananArray[d];
                                                yol[4] = arananArray[f];
                                                yol[5] = arananArray[g];
                                                yol[6] = arananArray[h];
                                                yol[7] = arananArray[i];
                                                yol[8] = arananArray[j];
                                                    yolEkle(yol);

                                            }

            //yolListele();

        }

    }
}
