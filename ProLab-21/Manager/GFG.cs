using System;
using System.Collections.Generic;

public class GFG
{

    public static readonly int NO_PARENT = -1;
    public List<Int32> kenarlar = new List<int>();
    public List<Int32> arananSehirMesafeleri = new List<int>();

    public  void dijkstra(int[,] komsulukMatrisi,int baslangicKenari)
    {
        int nKenar = komsulukMatrisi.GetLength(0);
        int[] enKisaMesafeler = new int[nKenar];
        bool[] eklenenler = new bool[nKenar];

        for (int sehirIndex = 0; sehirIndex < nKenar;
                                            sehirIndex++)
        {
            enKisaMesafeler[sehirIndex] = int.MaxValue;
            eklenenler[sehirIndex] = false;
        }

        enKisaMesafeler[baslangicKenari] = 0;

        int[] parents = new int[nKenar];

        parents[baslangicKenari] = NO_PARENT;

        for (int i = 1; i < nKenar; i++)
        {

            int enYakinKenar = -1;
            int EnKisaMesafe = int.MaxValue;
            for (int sehirIndex = 0;
                    sehirIndex < nKenar;
                    sehirIndex++)
            {
                if (!eklenenler[sehirIndex] &&
                    enKisaMesafeler[sehirIndex] <
                    EnKisaMesafe)
                {
                    enYakinKenar = sehirIndex;
                    EnKisaMesafe = enKisaMesafeler[sehirIndex];
                }
            }

            eklenenler[enYakinKenar] = true;

            for (int sehirIndex = 0;
                    sehirIndex < nKenar;
                    sehirIndex++)
            {
                int kenarMesafesi = komsulukMatrisi[enYakinKenar, sehirIndex];

                if (kenarMesafesi > 0
                    && ((EnKisaMesafe + kenarMesafesi) <
                        enKisaMesafeler[sehirIndex]))
                {
                    parents[sehirIndex] = enYakinKenar;
                    enKisaMesafeler[sehirIndex] = EnKisaMesafe +
                                                    kenarMesafesi;
                }
            }
        }

        cozumuEkranaYaz(baslangicKenari, enKisaMesafeler, parents,64);
    }
    public  void cozumuEkranaYaz(int baslangicKenari,
                                    int[] mesafeler,
                                    int[] parents,
                                    int bitisKenari)
    {
        int nKenar = mesafeler.Length;
     

        for (int sehirIndex = 0;
                sehirIndex < nKenar;
                sehirIndex++)
        {
            if (sehirIndex != baslangicKenari && sehirIndex == bitisKenari)
            {
                Console.Write("\n" + baslangicKenari + " -> ");
                Console.Write(bitisKenari + " \t\t ");
                Console.Write(mesafeler[bitisKenari] + "\t\t");
                arananSehirMesafeleri.Add(mesafeler[bitisKenari]);
                cozumYolunuEkranaYaz(sehirIndex, parents);
            }
        }
    }

    public  void cozumYolunuEkranaYaz(int gecerliKenar,int[] parents)
    {
        if (gecerliKenar == NO_PARENT)
        {
            return;
        }
        cozumYolunuEkranaYaz(parents[gecerliKenar], parents);
        Console.Write(gecerliKenar + " ");
        kenarlar.Add(gecerliKenar);

    }
}