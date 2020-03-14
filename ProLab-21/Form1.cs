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

        KomsulukMatrisiManager KomsulukMatrisiManager = new KomsulukMatrisiManager();
        public int[,] kMatris = new int[81, 81];
        public Form1()
        {
            InitializeComponent();
            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = DrawArea;
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

       
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            
            for(int i = 0;i< sehirList.Count();i++)
            {
                listBox1.Items.Add("["+sehirList[i].plaka+"] "+sehirList[i].sehirAdi.ToUpper() + " Komsu Sayisi:" + sehirList[i].komsuSayisi + "Kordinat X,Y: "+ sehirList[i].kordinatX+ " "+ sehirList[i].kordinatY);
                for(int i1 = 0; i1< sehirList[i].komsuSayisi;i1++)
                {
                    listBox1.Items.Add(i1+1 +")--->"+sehirList[i].komsular[i1].sehirAdi + " " + sehirList[i].komsuMesafe[i1]);
                }
            }
            
            
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            listBox2.Items.Clear();
            arananListesiIndis.Clear();
            listBox2.Items.Add("Kocaeli");
            if (checkedListBox1.CheckedItems.Count > 9)
            {
                MessageBox.Show("Maksimum il limitini geçtiniz.\nSeçilen il sayısı: " + checkedListBox1.CheckedItems.Count, "Maksimum Sınır Aşıldı", MessageBoxButtons.OK,MessageBoxIcon.Error);
            } else
            {
                
                for (int i = 0; i < checkedListBox1.CheckedItems.Count;i++)
                {
                    listBox2.Items.Add(checkedListBox1.CheckedItems[i].ToString());
                    //MessageBox.Show(sehirManager.GetSehir(checkedListBox1.CheckedItems[i].ToString()).plaka + " " + sehirManager.GetSehir(checkedListBox1.CheckedItems[i].ToString()).sehirAdi);
                    arananListesiIndis.Add(sehirManager.GetSehir(checkedListBox1.CheckedItems[i].ToString()).plaka - 1);
                }

            }

            listBox2.Items.Add("Kocaeli");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ISehir haritaIter = sehirManager.ilk;
            //int k = 0;
            //Label[] lDizi = new Label[81];
            //Image image1 = Image.FromFile(dosyaManager.Dosya.konumDosyaYolu);
            //while (haritaIter != null)
            //{
            //    lDizi[k] = new Label();
            //    lDizi[k].Text = "";
            //    lDizi[k].Width = 16;
            //    lDizi[k].Height = 32;
            //    lDizi[k].Image = image1;
            //    lDizi[k].BackColor = Color.Transparent;
            //    lDizi[k].TextAlign = ContentAlignment.MiddleCenter;
            //    lDizi[k].Location = new Point((int)haritaIter.kordinatX - 10, (int)haritaIter.kordinatY - 30);
            //    this.pictureBox1.Controls.Add(lDizi[k]);
            //    k++;
            //    haritaIter = haritaIter.ileri;
            //}


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

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g;
            
            Image image = Image.FromFile(dosyaManager.Dosya.haritaDosyaYolu);
            

            GFG t = new GFG();
            g = Graphics.FromImage(DrawArea);
            //g.Clear(Color.White);
            


            HatchBrush hatchBrush = new HatchBrush(HatchStyle.Horizontal, Color.Black);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            Pen mypen = new Pen(hatchBrush, 4);


            listBox4.Items.Clear();
            t.topluDijikstra(kMatris, 40, arananListesiIndis);
            listBox4.Items.Add(sehirManager.GetSehir(40 + 1).sehirAdi);
            Label[] lDizi = new Label[t.tamYol.Count];
            Image image1 = Image.FromFile(dosyaManager.Dosya.konumDosyaYolu);

            
            
            for (int i = 0; i< t.tamYol.Count;i++)
            {
                ISehir OncekiSehirBilgisi = null;
                if (i == 0)
                    OncekiSehirBilgisi = sehirManager.GetSehir(41);
                else
                    OncekiSehirBilgisi = sehirManager.GetSehir(t.tamYol[i - 1] + 1);
                
                    
                ISehir sehirBilgisi = sehirManager.GetSehir(t.tamYol[i] + 1);
                
                listBox4.Items.Add(sehirBilgisi.sehirAdi);
                g.DrawLine(mypen, OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY);

                
                
                
                    lDizi[i] = new Label();
                    lDizi[i].Text = "";
                    lDizi[i].Width = 16;
                    lDizi[i].Height = 32;
                    lDizi[i].Image = image1;
                    lDizi[i].BackColor = Color.Transparent;
                    lDizi[i].TextAlign = ContentAlignment.MiddleCenter;
                    lDizi[i].Location = new Point((int)sehirBilgisi.kordinatX-7, sehirBilgisi.kordinatY-28);
                    this.pictureBox1.Controls.Add(lDizi[i]);
                    
                
            }
            //            g.DrawImage(image, 0, 0);
            pictureBox1.SendToBack();
            //MessageBox.Show(t.toplamMinMesafe.ToString() + "KM");







            pictureBox1.Image = DrawArea;

            g.Dispose();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

       

            
        }




    }
}
