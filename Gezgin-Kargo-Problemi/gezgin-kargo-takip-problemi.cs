using ProLab_21.Entity;
using ProLab_21.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab_21
{
    
    public partial class Form1 : Form
    {
        readonly Bitmap DrawArea;
        readonly SehirManager sehirManager = new SehirManager();
        readonly DosyaManager dosyaManager = new DosyaManager();
        readonly List<DSehir> sehirList = new List<DSehir>();
        readonly List<Int32> arananListesiIndis = new List<int>();
        readonly KomsulukMatrisiManager KomsulukMatrisiManager = new KomsulukMatrisiManager();
        private readonly int[,] kMatris = new int[81, 81];
        private readonly Form2 mesafeListesiForm = new Form2();

        public Form1()
        {
            InitializeComponent();
            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = DrawArea;
            
            g = Graphics.FromImage(DrawArea);
            Image harita = Image.FromFile(dosyaManager.Dosya.haritaDosyaYolu);
            g.DrawImage(harita, 0, 0, 1300, 650);

            dosyaManager.sehirListesiAl(sehirManager);
            dosyaManager.kordinatEkle(sehirManager);
            dosyaManager.komsuListesiAl(sehirManager);
            sehirList = sehirManager.sehirListesi();
            for(int i = 0; i< sehirList.Count;i++)
            {
                if(sehirList[i].sehirAdi != "Kocaeli")
                    checkedListBox1.Items.Add(sehirList[i].sehirAdi);
            }
            kMatris = KomsulukMatrisiManager.KomsulukMatrisi(sehirManager);

        }

        private void LabelKonumlandir()
        {
            for (int i = 0; i < 120; i++)
            { 
                lDizi[i].Location = new Point(13000, 13000);
            }
        }
        private readonly List<Int32> yol0 = new List<int>();
        private readonly List<Int32> yol1 = new List<int>();
        private readonly List<Int32> yol2 = new List<int>();
        private readonly List<Int32> yol3 = new List<int>();
        private readonly List<Int32> yol4 = new List<int>();
        private readonly List<Int32> tumToplamMesafe = new List<int>();
        private readonly Label[] lDizi = new Label[120];
        private int minMesafe;
        private readonly Graphics g;
        private void YolBulClick()
        {
            mesafeListesiForm.listBox2.Items.Clear();
            listBox1.Items.Clear();
            yol0.Clear();
            yol1.Clear();
            yol2.Clear();
            yol3.Clear();
            yol4.Clear();
            tumToplamMesafe.Clear();
            g.Clear(Color.White);
            Image harita = Image.FromFile(dosyaManager.Dosya.haritaDosyaYolu);
            g.DrawImage(harita, 0, 0, 1300, 650);
            LabelKonumlandir();
            listBox2.Items.Clear();
            arananListesiIndis.Clear();
            richTextBox2.Text = "";
            ArananListesiOlustusur();

            YolBul(arananListesiIndis, kMatris, 0);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            if(yol0.Count > 0 && yol1.Count > 0)
                listBox1.Items.Add("Tüm Yollar");
            if (yol0.Count > 0)
            {
                listBox1.Items.Add("1.Yol");
                listBox1.SetSelected(0, true);
            }
            if (yol1.Count > 0)
                listBox1.Items.Add("2.Yol");
            if (yol2.Count > 0)
                listBox1.Items.Add("3.Yol");
            if (yol3.Count > 0)
                listBox1.Items.Add("4.Yol");
            if (yol4.Count > 0)
                listBox1.Items.Add("5.Yol");
            EnKisaMesafeyiLabeleYaz();
            if (yol0.Count > 0)
                dosyaManager.ciktiDosyasiOlustur(sehirManager, arananListesiIndis, yol0, yol1, yol2, yol3, yol4, tumToplamMesafe);

        }

        private void EnKisaMesafeyiLabeleYaz()
        {
            minMesafe = Int32.MaxValue;
            for(int i = 0; i<tumToplamMesafe.Count;i++)
            {
                if (tumToplamMesafe[i] < minMesafe)
                    minMesafe = tumToplamMesafe[i];
            }
            label5.Text = minMesafe.ToString()+" KM";
        }
        private void ArananListesiOlustusur()
        {

            if (checkedListBox1.CheckedItems.Count > 9 ||checkedListBox1.CheckedItems.Count < 1)
            {
                richTextBox2.Text = "";
                MessageBox.Show("Limit dışı seçim yaptınız.\nSeçilen il sayısı: " + checkedListBox1.CheckedItems.Count, "Maksimum Sınır Aşıldı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
           
                listBox2.Items.Add("Kocaeli");
                mesafeListesiForm.listBox2.Items.Add("Kocaeli");
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    listBox2.Items.Add(checkedListBox1.CheckedItems[i].ToString());
                    mesafeListesiForm.listBox2.Items.Add(checkedListBox1.CheckedItems[i].ToString()); ;
                    arananListesiIndis.Add(sehirManager.GetSehir(checkedListBox1.CheckedItems[i].ToString()).plaka - 1);
                }
                listBox2.Items.Add("Kocaeli");
                mesafeListesiForm.listBox2.Items.Add("Kocaeli");
            }

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 81; i++)
            {
                for (int k = 0; k < 81; k++)
                {
                    richTextBox1.Text += kMatris[i, k] + "  ";
                }
                richTextBox1.Text += "\n";


            }
            Image image1 = Image.FromFile(dosyaManager.Dosya.konumDosyaYolu);

            for(int i = 0; i< 120; i++)
            {
                lDizi[i] = new Label
                {
                    Text = "",
                    Width = 16,
                    Height = 32,
                    Image = image1,
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(13000, 13000)
                };
                this.pictureBox1.Controls.Add(lDizi[i]);
            }


        }


        private void HaritadaCiz(int x,int y,int x1,int y1,int status,int color1,int color2,int color3)
        {

            /*
             230,57,70
             29,53,87
             */
            SolidBrush Normal = new SolidBrush(Color.FromArgb(color1, color2, color3));
            SolidBrush Kalin = new SolidBrush(Color.FromArgb(0, 175, 0));
            Pen mypen = new Pen(Kalin, 2);
            if (status == 0)
            {
               mypen = new Pen(Normal, 2);
            } else if(status == 1)
            {
                mypen = new Pen(Kalin, 8);
            }
            g.DrawLine(mypen, x, y, x1, y1);
        }

        private void YolBul(List<Int32> arananIndisListesi,int[,] matris,int tur)
        {
            int[,] newMatris = new int[81, 81];
            for(int i = 0; i<81;i++)
            {
                for(int k = 0; k<81;k++)
                {
                    newMatris[i, k] = matris[i, k];
                }
            }
            List<Int32> arananIndisListesiCopy = new List<int>();
            for(int i = 0; i< arananIndisListesi.Count;i++)
            {
                arananIndisListesiCopy.Add(arananIndisListesi[i]);
            }
            if (tur < 5)
            {
                YolBulucu t = new YolBulucu();
            t.topluDijikstra(newMatris, 40, arananIndisListesiCopy, 0);
            richTextBox2.Text += sehirManager.GetSehir(41).sehirAdi +"("+ sehirManager.GetSehir(41).plaka.ToString()+") ";
            for (int i = 0; i < t.tamYol.Count; i++)
            {
                switch(tur)
                    {
                        case 0:
                            yol0.Add(t.tamYol[i]);
                            break;
                        case 1:
                            yol1.Add(t.tamYol[i]);
                            break;
                        case 2:
                            yol2.Add(t.tamYol[i]);
                            break;
                        case 3:
                            yol3.Add(t.tamYol[i]);
                            break;
                        case 4:
                            yol4.Add(t.tamYol[i]);
                            break;

                    }
                    DSehir OncekiSehirBilgisi;
                    if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                        OncekiSehirBilgisi = sehirManager.GetSehir(t.tamYol[i - 1] + 1);
                }


                DSehir sehirBilgisi = sehirManager.GetSehir(t.tamYol[i] + 1);

                richTextBox2.Text += "  -  " + sehirBilgisi.sehirAdi + "("+sehirBilgisi.plaka.ToString()+")";


        }
        richTextBox2.Text += "\n----[TOPLAM MESAFE: "+ t.toplamMinMesafe.ToString()+ "]----\n\n";
            tumToplamMesafe.Add(t.toplamMinMesafe);


                if (t.tamYol.Count >= 5)
            {
                BurayaDon:
                Random random = new Random();
                int sayi = random.Next(t.tamYol.Count);
                for(int i = 0; i< arananListesiIndis.Count;i++)
                {
                    if (t.tamYol[sayi] == arananListesiIndis[i] || sayi == 0)
                        goto BurayaDon;
                }
                    newMatris[t.tamYol[sayi - 1], t.tamYol[sayi]] = 0;
                    YolBul(arananListesiIndis, newMatris, tur + 1);

            }
            

            }
        }

        private void YolCizClick()
        {
            mesafeListesiForm.listBox1.Items.Clear();
            mesafeListesiForm.label5.Location = new Point(120, 25);


            mesafeListesiForm.listBox1.Items.Add("Kocaeli");
            this.tabControl1.SelectedTab = tabPage5;
            g.Clear(Color.White);
            Image harita = Image.FromFile(dosyaManager.Dosya.haritaDosyaYolu);
            g.DrawImage(harita, 0, 0, 1300, 650);
            LabelKonumlandir();

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Yol Seçimi Yapılmadi");

            }
            else
            {
                
                int tempIndex = 0;
                List<Int32> temp = new List<int>();

                if (listBox1.SelectedItem.ToString() == "1.Yol")
                {
                    temp = yol0;
                    mesafeListesiForm.label5.Text = "1.Yol";
                    tempIndex = 0;
                }
                else if (listBox1.SelectedItem.ToString() == "2.Yol")
                {
                    mesafeListesiForm.label5.Text = "2.Yol";
                    temp = yol1;
                    tempIndex = 1;
                }
                else if (listBox1.SelectedItem.ToString() == "3.Yol")
                {
                    mesafeListesiForm.label5.Text = "3.Yol";
                    temp = yol2;
                    tempIndex = 2;
                }
                else if (listBox1.SelectedItem.ToString() == "4.Yol")
                {
                    mesafeListesiForm.label5.Text = "4.Yol";
                    temp = yol3;
                    tempIndex = 3;
                }
                else if (listBox1.SelectedItem.ToString() == "5.Yol")
                {
                    mesafeListesiForm.label5.Text = "5.Yol";
                    temp = yol4;
                    tempIndex = 4;
                }
                else if (listBox1.SelectedItem.ToString() == "Tüm Yollar")
                {
                    TumYollarCiz();
                }else
                {
                    MessageBox.Show("Hatalı Seçim");
                }
                    

                if(listBox1.SelectedItem.ToString() != "Tüm Yollar")
                { 
                for (int i = 0; i < temp.Count; i++)
                {
                        DSehir OncekiSehirBilgisi;
                        if (i == 0)
                    {
                        OncekiSehirBilgisi = sehirManager.GetSehir(41);
                    }
                    else
                    {
                        OncekiSehirBilgisi = sehirManager.GetSehir(temp[i - 1] + 1);
                    }


                    DSehir sehirBilgisi = sehirManager.GetSehir(temp[i] + 1);
                    mesafeListesiForm.listBox1.Items.Add(sehirBilgisi.sehirAdi);


                    HaritadaCiz(OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY,0, 29, 53, 87);
                    lDizi[i].Location = new Point(sehirBilgisi.kordinatX-7, sehirBilgisi.kordinatY-25);

                }
                mesafeListesiForm.label2.Text = tumToplamMesafe[tempIndex].ToString() + " KM";

                mesafeListesiForm.ShowDialog();
            }
            }

        }
        private void TumYollarCiz()
        {
            for(int i = 0; i< yol0.Count;i++)
            {

                DSehir OncekiSehirBilgisi;
                if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(yol0[i - 1] + 1);
                }

                DSehir sehirBilgisi = sehirManager.GetSehir(yol0[i] + 1);
                if(tumToplamMesafe[0]== minMesafe)
                {
                    mesafeListesiForm.listBox1.Items.Add(sehirBilgisi.sehirAdi);
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY, 1,0,0,0);
                    lDizi[i].Location = new Point(sehirBilgisi.kordinatX - 7, sehirBilgisi.kordinatY - 25);
                } else
                {
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX , OncekiSehirBilgisi.kordinatY  , sehirBilgisi.kordinatX  , sehirBilgisi.kordinatY , 0, 255, 123, 0); //Siyah
                }
            }
            for (int i = 0; i < yol1.Count; i++)
            {

                DSehir OncekiSehirBilgisi;
                if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(yol1[i - 1] + 1);
                }


                DSehir sehirBilgisi = sehirManager.GetSehir(yol1[i] + 1);
                if (tumToplamMesafe[1] == minMesafe)
                {
                    mesafeListesiForm.listBox1.Items.Add(sehirBilgisi.sehirAdi);
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY, 1,0,0,0);
                    lDizi[i].Location = new Point(sehirBilgisi.kordinatX - 7, sehirBilgisi.kordinatY - 25);
                }
                else
                {
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX , OncekiSehirBilgisi.kordinatY , sehirBilgisi.kordinatX , sehirBilgisi.kordinatY , 0, 0, 75, 255); //Mavi
                }
            }            
            for (int i = 0; i < yol2.Count; i++)
            {

                DSehir OncekiSehirBilgisi;
                if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(yol2[i - 1] + 1);
                }


                DSehir sehirBilgisi = sehirManager.GetSehir(yol2[i] + 1);
                if (tumToplamMesafe[2] == minMesafe)
                {
                    mesafeListesiForm.listBox1.Items.Add(sehirBilgisi.sehirAdi);
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY, 1,0,0,0);
                    lDizi[i].Location = new Point(sehirBilgisi.kordinatX - 7, sehirBilgisi.kordinatY - 25);
                }
                else
                {
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX , OncekiSehirBilgisi.kordinatY , sehirBilgisi.kordinatX , sehirBilgisi.kordinatY , 0, 255, 0, 0); //Kırmızı
                }
            }            
            for (int i = 0; i < yol3.Count; i++)
            {
                DSehir OncekiSehirBilgisi;
                if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(yol3[i - 1] + 1);
                }


                DSehir sehirBilgisi = sehirManager.GetSehir(yol3[i] + 1);
                if (tumToplamMesafe[3] == minMesafe)
                {
                    mesafeListesiForm.listBox1.Items.Add(sehirBilgisi.sehirAdi);
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY, 1,0,0,0);
                    lDizi[i].Location = new Point(sehirBilgisi.kordinatX - 7, sehirBilgisi.kordinatY - 25);
                }
                else
                {
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX , OncekiSehirBilgisi.kordinatY , sehirBilgisi.kordinatX , sehirBilgisi.kordinatY , 0, 255, 0, 238); //Kahverengi
                }
            }            
            for (int i = 0; i < yol4.Count; i++)
            {
                DSehir OncekiSehirBilgisi;
                if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(yol4[i - 1] + 1);
                }


                DSehir sehirBilgisi = sehirManager.GetSehir(yol4[i] + 1);
                if (tumToplamMesafe[4] == minMesafe)
                {
                    mesafeListesiForm.listBox1.Items.Add(sehirBilgisi.sehirAdi);
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY, 1,0,0,0);
                    lDizi[i].Location = new Point(sehirBilgisi.kordinatX - 7, sehirBilgisi.kordinatY - 25);
                }
                else
                {
                    HaritadaCiz(OncekiSehirBilgisi.kordinatX , OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX , sehirBilgisi.kordinatY , 0, 0,0,0); //siyah
                }
            }


            mesafeListesiForm.label2.Text = minMesafe.ToString() + " KM";
            mesafeListesiForm.label5.Location = new Point(90, 10);
            mesafeListesiForm.label5.Text = "Tüm Yollar\nEn Kisa Bilgisi";
            mesafeListesiForm.ShowDialog();

        }





        private void YolBulBtn_Click(object sender, EventArgs e)
        {
            YolBulClick();
        }

        private void YolCizBtn_Click(object sender, EventArgs e)
        {
        YolCizClick();
        }
    }
}
