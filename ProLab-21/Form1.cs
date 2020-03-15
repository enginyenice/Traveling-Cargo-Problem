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
            haritadaCiz();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            Pen mypen = new Pen(hatchBrush, 4);



            listBox4.Items.Clear();
            t.topluDijikstra(kMatris, 40, arananListesiIndis);
            listBox4.Items.Add(sehirManager.GetSehir(40 + 1).sehirAdi);
            Label[] lDizi = new Label[81];
            Image image1 = Image.FromFile(dosyaManager.Dosya.konumDosyaYolu);

            ISehir iterSehir = sehirManager.ilk;
            int k = 0;

            while (iterSehir != null)
            {
                lDizi[k] = new Label();
                lDizi[k].Text = "";
                lDizi[k].Width = 16;
                lDizi[k].Height = 32;
                lDizi[k].Image = image1;
                lDizi[k].BackColor = Color.Transparent;
                lDizi[k].TextAlign = ContentAlignment.MiddleCenter;
                lDizi[k].Location = new Point((int)iterSehir.kordinatX - 10, (int)iterSehir.kordinatY - 30);
                this.pictureBox1.Controls.Add(lDizi[k]);
                k++;
                iterSehir = iterSehir.ileri;

            }

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
                g.DrawLine(mypen, OncekiSehirBilgisi.kordinatX, OncekiSehirBilgisi.kordinatY, sehirBilgisi.kordinatX, sehirBilgisi.kordinatY);

            }
            pictureBox1.SendToBack();
            pictureBox1.Image = DrawArea;
            g.Dispose();
            label5.Text = t.toplamMinMesafe.ToString() + "KM";
        }



    }
}
