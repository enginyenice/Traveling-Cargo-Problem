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
        Bitmap DrawArea;
        SehirManager sehirManager = new SehirManager();
        DosyaManager dosyaManager = new DosyaManager();
        List<ISehir> sehirList = new List<ISehir>();
        List<Int32> arananListesiIndis = new List<int>();
        public int[] arananArray;
        KomsulukMatrisiManager KomsulukMatrisiManager = new KomsulukMatrisiManager();
        public int[,] kMatris = new int[81, 81];

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

       
       public void labelKonumlandir()
        {
            for (int i = 0; i < 120; i++)
            { 
                lDizi[i].Location = new Point(13000, 13000);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Image harita = Image.FromFile(dosyaManager.Dosya.haritaDosyaYolu);
            g.DrawImage(harita, 0, 0, 1300, 650);
            labelKonumlandir();
            listBox2.Items.Clear();
            arananListesiIndis.Clear();
            richTextBox2.Text = "";
            ArananListesiOlustusur();

            yolBul(arananListesiIndis,kMatris,0);
            for(int i = 0; i< checkedListBox1.Items.Count;i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        public void ArananListesiOlustusur()
        {

            if (checkedListBox1.CheckedItems.Count > 9 ||checkedListBox1.CheckedItems.Count < 1)
            {
                richTextBox2.Text = "";
                MessageBox.Show("Limit dışı seçim yaptınız.\nSeçilen il sayısı: " + checkedListBox1.CheckedItems.Count, "Maksimum Sınır Aşıldı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox2.Items.Add("Kocaeli");
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    listBox2.Items.Add(checkedListBox1.CheckedItems[i].ToString());
                    arananListesiIndis.Add(sehirManager.GetSehir(checkedListBox1.CheckedItems[i].ToString()).plaka - 1);
                }
                listBox2.Items.Add("Kocaeli");
            }

           
        }
        public Label[] lDizi = new Label[120];
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Image image1 = Image.FromFile(dosyaManager.Dosya.konumDosyaYolu);

            for(int i = 0; i< 120; i++)
            {
                lDizi[i] = new Label();
                lDizi[i].Text = "";
                lDizi[i].Width = 16;
                lDizi[i].Height = 32;
                lDizi[i].Image = image1;
                lDizi[i].BackColor = Color.Transparent;
                lDizi[i].TextAlign = ContentAlignment.MiddleCenter;
                lDizi[i].Location = new Point(13000,13000);
                this.pictureBox1.Controls.Add(lDizi[i]);
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 81; i++)
            {
                richTextBox1.Text += "{";
                for (int k = 0; k < 81; k++)
                {
                    richTextBox1.Text += kMatris[i, k] + ",";
                }
                richTextBox1.Text += "},\n";


            }
        }
        Graphics g;
        
        public void haritadaCiz(int x,int y,int x1,int y1,int color)
        {
            
            GFG t = new GFG();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush= new SolidBrush(Color.Black);
            SolidBrush darkOrangeBrus = new SolidBrush(Color.DarkOrange);
            SolidBrush purpleBrush = new SolidBrush(Color.Purple);
             Pen mypen = new Pen(redBrush, 3);
            if (color == 1)
               mypen = new Pen(blueBrush, 3);
            else if(color == 2)
                mypen = new Pen(blackBrush, 3);            
            else if(color == 3)
                mypen = new Pen(darkOrangeBrus, 3);            
            else if(color == 4)
                mypen = new Pen(purpleBrush, 3);

            g.DrawLine(mypen, x, y, x1, y1);

        }
        
        
        public void haritadaCiz()
        {
            Graphics g;
            GFG t = new GFG();
            g = Graphics.FromImage(DrawArea);
            g.Clear(Color.White);
            Image harita = Image.FromFile(dosyaManager.Dosya.haritaDosyaYolu);
            g.DrawImage(harita, 0, 0, 1300, 650);
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.Horizontal, Color.Black);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Pen mypen = new Pen(hatchBrush, 3);
            listBox4.Items.Clear();

          
            List<Int32> arananListCopy = new List<int>();
            for (int i = 0; i < arananListesiIndis.Count; i++)
                arananListCopy.Add(arananListesiIndis[i]);

            t.topluDijikstra(kMatris, 40, arananListesiIndis,0);
            listBox4.Items.Add(sehirManager.GetSehir(40 + 1).sehirAdi);
            /*********************************************/

           





            /*********************************************/




















            for (int i = 0; i < t.tamYol.Count; i++)
            {

                ISehir OncekiSehirBilgisi = null;
                if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(t.tamYol[i - 1] + 1);
                }


                ISehir sehirBilgisi = sehirManager.GetSehir(t.tamYol[i] + 1);

                listBox4.Items.Add(sehirBilgisi.sehirAdi);
                richTextBox2.Text += sehirBilgisi.sehirAdi + " ";
                g.DrawLine(mypen, OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY);
                lDizi[i].Location = new Point(sehirBilgisi.kordinatX-8, sehirBilgisi.kordinatY-25);

            }
            /*
                        pictureBox1.SendToBack();
                        pictureBox1.Image = DrawArea;
                        g.Dispose();
                        label5.Text = t.toplamMinMesafe.ToString() + "KM";
                        */

            /******/
            listBox4.Items.Add("-------------------");
        BasaDon:
            Random random = new Random();
            int sayi = random.Next(t.tamYol.Count);
            for (int i = 0; i < arananListCopy.Count; i++)
            {
                if (arananListCopy[i] == t.tamYol[sayi] || sayi == 0)
                    goto BasaDon;
            }

            if (t.tamYol[sayi] != 40)
            {

                Graphics g1;
                g1 = Graphics.FromImage(DrawArea);
                g1.DrawImage(harita, 0, 0, 1300, 650);
                Pen bluepen = new Pen(blueBrush, 2);







                GFG t2 = new GFG();
                kMatris[t.tamYol[sayi - 1], t.tamYol[sayi]] = 0;
                t2.topluDijikstra(kMatris, 40, arananListCopy, 0);
                for (int i = 0; i < t2.tamYol.Count; i++)
                {

                    ISehir OncekiSehirBilgisi = null;
                    if (i == 0)
                    {
                        OncekiSehirBilgisi = sehirManager.GetSehir(41);
                    }
                    else
                    {
                        OncekiSehirBilgisi = sehirManager.GetSehir(t2.tamYol[i - 1] + 1);
                    }


                    ISehir sehirBilgisi = sehirManager.GetSehir(t2.tamYol[i] + 1);

                    listBox4.Items.Add(sehirBilgisi.sehirAdi);
                    g1.DrawLine(bluepen, OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY);
                    //lDizi[i].Location = new Point(sehirBilgisi.kordinatX - 8, sehirBilgisi.kordinatY - 25);

                }

            }


            /****/

            pictureBox1.SendToBack();
            pictureBox1.Image = DrawArea;
            g.Dispose();
            label5.Text = t.toplamMinMesafe.ToString() + "KM";
        }

        public void yolBul(List<Int32> arananIndisListesi,int[,] matris,int tur)
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
            GFG t = new GFG();
            listBox4.Items.Clear();
            //richTextBox2.Text = "";
            t.topluDijikstra(newMatris, 40, arananIndisListesiCopy, 0);
            listBox4.Items.Add(sehirManager.GetSehir(40 + 1).sehirAdi);
            richTextBox2.Text += sehirManager.GetSehir(41).sehirAdi;
            for (int i = 0; i < t.tamYol.Count; i++)
            {
                ISehir OncekiSehirBilgisi = null;
                if (i == 0)
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                }
                else
                {
                    OncekiSehirBilgisi = sehirManager.GetSehir(t.tamYol[i - 1] + 1);
                }


                ISehir sehirBilgisi = sehirManager.GetSehir(t.tamYol[i] + 1);

                listBox4.Items.Add(sehirBilgisi.sehirAdi);
                richTextBox2.Text += " - " + sehirBilgisi.sehirAdi;

                haritadaCiz(OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY, tur);
                lDizi[i].Location = new Point(sehirBilgisi.kordinatX - 8, sehirBilgisi.kordinatY - 25);

            }
            richTextBox2.Text += "Toplam Mesafe: "+ t.toplamMinMesafe.ToString()+ "\n";
            label5.Text = t.toplamMinMesafe.ToString() + "KM";
            
            
            if(t.tamYol.Count > 5)
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
                    yolBul(arananListesiIndis, newMatris, tur + 1);

            }
            

            }
        }
    }
}
