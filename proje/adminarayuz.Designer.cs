namespace proje
{
    partial class adminarayuz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminarayuz));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butonekle = new System.Windows.Forms.Button();
            this.butonsil = new System.Windows.Forms.Button();
            this.butonguncelle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 503);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1840, 518);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // butonekle
            // 
            this.butonekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonekle.Location = new System.Drawing.Point(292, 161);
            this.butonekle.Name = "butonekle";
            this.butonekle.Size = new System.Drawing.Size(180, 110);
            this.butonekle.TabIndex = 12;
            this.butonekle.Text = "EKLE\r\n(F6)";
            this.butonekle.UseVisualStyleBackColor = true;
            this.butonekle.Click += new System.EventHandler(this.butonekle_Click);
            // 
            // butonsil
            // 
            this.butonsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonsil.Location = new System.Drawing.Point(517, 161);
            this.butonsil.Name = "butonsil";
            this.butonsil.Size = new System.Drawing.Size(180, 110);
            this.butonsil.TabIndex = 13;
            this.butonsil.Text = "SİL\r\n(F7)";
            this.butonsil.UseVisualStyleBackColor = true;
            this.butonsil.Click += new System.EventHandler(this.butonsil_Click);
            // 
            // butonguncelle
            // 
            this.butonguncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonguncelle.Location = new System.Drawing.Point(741, 161);
            this.butonguncelle.Name = "butonguncelle";
            this.butonguncelle.Size = new System.Drawing.Size(180, 110);
            this.butonguncelle.TabIndex = 14;
            this.butonguncelle.Text = "GÜNCELLE\r\n(F8)";
            this.butonguncelle.UseVisualStyleBackColor = true;
            this.butonguncelle.Click += new System.EventHandler(this.butonguncelle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(23, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 29);
            this.label6.TabIndex = 17;
            this.label6.Text = "Kitap Sorgulama";
            // 
            // txtArama
            // 
            this.txtArama.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.Location = new System.Drawing.Point(233, 445);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(673, 34);
            this.txtArama.TabIndex = 16;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = global::proje.Properties.Resources.Back_Button_PNG_Pic1;
            this.button1.Location = new System.Drawing.Point(1724, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 70);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = global::proje.Properties.Resources.png_transparent_computer_icons_icon_design_house_symbol_qualifications_wales_main_menu_angle_building_office;
            this.button2.Location = new System.Drawing.Point(1824, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 70);
            this.button2.TabIndex = 19;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(961, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 110);
            this.button3.TabIndex = 20;
            this.button3.Text = "Günü Gelen\r\nKitaplar\r\n(F9)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // adminarayuz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::proje.Properties.Resources._1078109_1920x1080;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.butonguncelle);
            this.Controls.Add(this.butonsil);
            this.Controls.Add(this.butonekle);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "adminarayuz";
            this.Text = "Kütüphane Yönetim Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.adminarayuz_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butonekle;
        private System.Windows.Forms.Button butonsil;
        private System.Windows.Forms.Button butonguncelle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

