using ProLab_21.Entity;
using ProLab_21.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab_21
{
    public partial class Form1 : Form
    {
        SehirManager sehirManager = new SehirManager();
        DosyaManager dosyaManager = new DosyaManager();
        YolBulucuManager yolBulucuManager = new YolBulucuManager();
        List<ISehir> sehirList = new List<ISehir>();
        List<Int32> arananListesi = new List<int>();

        KomsulukMatrisiManager KomsulukMatrisiManager = new KomsulukMatrisiManager();
        public int[,] kMatris = new int[81, 81];
        public Form1()
        {
            InitializeComponent();
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

            /*Button b = new Button();
            b.Text = "Butttonum benim canim benim";
            b.Location = new Point(10, 10);
            b.Size = new Size(100, 20);

            tabPage4.Controls.Add(b);
            */
            Label[] lDizi = new Label[81];
            ISehir haritaIter = sehirManager.ilk;
            int k = 0;
            while (haritaIter != null)
            {
                lDizi[k] = new Label();
                lDizi[k].Text = haritaIter.sehirAdi;
                lDizi[k].Width = 60;
                lDizi[k].Height = 15;
                lDizi[k].BackColor = Color.Transparent;
                lDizi[k].ForeColor = Color.Black;
                lDizi[k].TextAlign = ContentAlignment.MiddleCenter;
                lDizi[k].Location = new Point(((int)haritaIter.kordinatX * 2 - (haritaIter.kordinatX * 5) / 100)-80, ((int)haritaIter.kordinatY * 2 + (haritaIter.kordinatY * 40) / 100)-100);
                tabPage4.Controls.Add(lDizi[k]);
                k++;
                haritaIter = haritaIter.ileri;
            }
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
            arananListesi.Clear();
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
                    arananListesi.Add(sehirManager.GetSehir(checkedListBox1.CheckedItems[i].ToString()).plaka);
                }

            }

            listBox2.Items.Add("Kocaeli");
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

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
