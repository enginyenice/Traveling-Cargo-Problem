namespace ProLab_21
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(303, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Şehir Listesi List<ISehir>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(167, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(296, 225);
            this.listBox1.TabIndex = 3;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(149, 259);
            this.checkedListBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Yol Bul";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 287);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
    }
}

