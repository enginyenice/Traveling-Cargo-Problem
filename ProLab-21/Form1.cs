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
        List<ISehir> sehirList = new List<ISehir>();
        KomsulukMatrisiManager KomsulukMatrisiManager = new KomsulukMatrisiManager();
        
        public Form1()
        {
            InitializeComponent();
            dosyaManager.sehirListesiAl(sehirManager);
            dosyaManager.komsuListesiAl(sehirManager);
            sehirList = sehirManager.sehirListesi();
            for(int i = 0; i< sehirList.Count;i++)
            {
                if(sehirList[i].sehirAdi != "Kocaeli")
                    checkedListBox1.Items.Add(sehirList[i].sehirAdi);
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            for(int i = 0;i< sehirList.Count();i++)
            {
                listBox1.Items.Add("["+sehirList[i].plaka+"] "+sehirList[i].sehirAdi.ToUpper() + " Komsu Sayisi:" + sehirList[i].komsuSayisi);
                for(int i1 = 0; i1< sehirList[i].komsuSayisi;i1++)
                {
                    listBox1.Items.Add(i1+1 +")--->"+sehirList[i].komsular[i1].sehirAdi + " " + sehirList[i].komsuMesafe[i1]);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
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
                    
                }

            }

            listBox2.Items.Add("Kocaeli");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "X" + "|\t";
            for (int k = 0; k< 81;k++)
            {
                int a = (k + 1) % 10;
                richTextBox1.Text += a  + "  ";
                
            }
            richTextBox1.Text += "\n";
            int[,] kMatris = new int[81, 81];
            kMatris = KomsulukMatrisiManager.KomsulukMatrisi(sehirManager);
            for(int i = 0; i<81;i++)
            {
                richTextBox1.Text += i+1 + "|\t";
                for (int k = 0; k< 81;k++)
                {
                    richTextBox1.Text += kMatris[i, k] + "  ";
                }
                richTextBox1.Text += "\n";


            }
        }
    }
}
