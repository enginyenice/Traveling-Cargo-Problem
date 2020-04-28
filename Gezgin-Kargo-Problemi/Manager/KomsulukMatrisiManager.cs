using ProLab_21.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_21.Manager
{
    class KomsulukMatrisiManager
    {
        public int[,] matris = new int[81, 81];

        public KomsulukMatrisiManager()
        {
            for(int i = 0; i< 81; i++)
            {
                for(int l = 0; l<81;l++)
                {
                    matris[i, l] = 0;
                }
            }
        }
        public int[,] KomsulukMatrisi(SehirManager sehirManager)
        {
            
            
            DSehir iter = sehirManager.ilk;
            int main = 0;
            
            while(iter !=null)
            {

                for(int i = 0; i < iter.komsuSayisi;i++)
                {
                    matris[main, iter.komsular[i].plaka - 1] = iter.komsuMesafe[i];
                }

                main++;
                iter = iter.ileri;
            }
            
            return matris;
        }
    }
}
