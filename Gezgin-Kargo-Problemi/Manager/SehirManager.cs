using ProLab_21.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_21.Manager
{
    class SehirManager
    {
        public DSehir ilk;
        public DSehir son;
        

        public SehirManager()
        {
            ilk = null;
            son = ilk;
        }
        public bool sehirEkle(int plaka,string sehirAdi)
        {
            try{
                DSehir node = new DSehir(plaka, sehirAdi);
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
        public List<DSehir> sehirListesi()
        {
            List<DSehir> sehirList = new List<DSehir>();
            DSehir iter;
            iter = ilk;
            while(iter != null)
            {
                sehirList.Add(iter);
                iter = iter.ileri;
            }
            
            return sehirList;
        }
        public bool komsuEkle(string sahipSehir,string komsuSehir,int maliyet)
        {
            DSehir sahipNode, komsuNode;
            sahipNode = ilk;
            komsuNode = ilk;

            while(sahipNode != null)
            {
                if(sahipNode.sehirAdi == sahipSehir)
                    break;
                sahipNode = sahipNode.ileri;
            }

            for(int i = 0; i<sahipNode.komsuSayisi;i++)
            {
                if (sahipNode.komsular[i].sehirAdi == komsuSehir)
                    return false;
            }

                while (komsuNode != null)
                {
                    if (komsuNode.sehirAdi == komsuSehir)
                        break;
                    komsuNode = komsuNode.ileri;
                }

                sahipNode.komsular[sahipNode.komsuSayisi] = komsuNode;
                sahipNode.komsuMesafe[sahipNode.komsuSayisi] = maliyet;
                sahipNode.komsuSayisi += 1;

                komsuNode.komsular[komsuNode.komsuSayisi] = sahipNode;
                komsuNode.komsuMesafe[komsuNode.komsuSayisi] = maliyet;
                komsuNode.komsuSayisi += 1;
            return true;


        }
        public DSehir GetSehir(string sehirAdi)
        {
            DSehir sehirBilgileri = ilk;
            while(sehirBilgileri != null)
            {
                if (sehirBilgileri.sehirAdi == sehirAdi)
                    break;
                sehirBilgileri = sehirBilgileri.ileri;
            }
            


            return sehirBilgileri;
        }

        public DSehir GetSehir(int plaka)
        {
            DSehir sehirBilgileri = ilk;
            while (sehirBilgileri != null)
            {
                if (sehirBilgileri.plaka == plaka)
                    break;
                sehirBilgileri = sehirBilgileri.ileri;
            }



            return sehirBilgileri;
        }
        public void kordinatEkle(int plaka,int x,int y)
        {
            DSehir sehirBilgileri = ilk;
            while(sehirBilgileri != null)
            {
                if(sehirBilgileri.plaka == plaka)
                {
                    break;
                }
                sehirBilgileri = sehirBilgileri.ileri;
            }
            sehirBilgileri.kordinatX = x;
            sehirBilgileri.kordinatY = y;
        }

    }
}
