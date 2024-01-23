using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    public partial class adminekle : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; user=root;password=;database=ejhquykv_library");
        MySqlCommand cmd;
        MySqlCommand cmd1;
        MySqlCommand otocmd;
        MySqlCommand arti1;
        MySqlCommand ototarihkal;
        MySqlDataAdapter adapter;
        DataTable dt;
        public adminekle()
        {
            InitializeComponent();
        }
        void VeriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT kitap_id,kullanici_ismi,kitap_adi,kitap_yazari,alinma_tarihi,geri_getirme_tarihi FROM kitaplar", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void adminekle_Load(object sender, EventArgs e)
        {
            VeriGetir();
            dataGridView1.Columns["kitap_adi"].HeaderText = "Kitap Adı";
            dataGridView1.Columns["kitap_id"].HeaderText = "Kitap No";
            dataGridView1.Columns["kitap_yazari"].HeaderText = "Kitap Yazarı";
            dataGridView1.Columns["kullanici_ismi"].HeaderText = "Alan Kişi";
            dataGridView1.Columns["geri_getirme_tarihi"].HeaderText = "Geri Getirme Tarihi";
            dataGridView1.Columns["alinma_tarihi"].HeaderText = "Alınma Tarihi";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            giris giris = new giris();  
            giris.Show();
            this.Close(); 
        }

        private void adminekle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                butonekle.PerformClick();
            }
        }

        private void butonekle_Click(object sender, EventArgs e)
        {
            using (var uyarıForm = new Form())
            {
                uyarıForm.Text = "Uyarı";
                uyarıForm.Size = new System.Drawing.Size(300, 200);

                Label uyarıLabel = new Label();
                uyarıLabel.Text = "Onaylıyor musun?";
                uyarıLabel.Location = new System.Drawing.Point(30, 20);

                CheckBox onayCheckBox = new CheckBox();
                onayCheckBox.Text = "Onaylıyorum";
                onayCheckBox.Location = new System.Drawing.Point(30, 60);

                Button onayButton = new Button();
                onayButton.Text = "Kitap Ekle";
                onayButton.Location = new System.Drawing.Point(30, 100);
                onayButton.Click += (s, ev) =>
                {
                    // CheckBox seçili ise kitap eklemeyi gerçekleştir
                    if (onayCheckBox.Checked)
                    {
                        string sql = "INSERT INTO kitaplar(kullanici_ismi,kitap_adi,kitap_yazari,alinma_tarihi) VALUES (@kullanici_ismi,@kitap_adi,@kitap_yazari,@alinma_tarihi)";
                        string kalici = "INSERT INTO kalici(kullanici_ismi,kitap_adi,kitap_yazari,alinma_tarihi) VALUES (@kullanici_ismi,@kitap_adi,@kitap_yazari,@alinma_tarihi)";
                        cmd1 = new MySqlCommand(kalici, conn);
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@kitap_adi", txtAd.Text);
                        cmd.Parameters.AddWithValue("@kitap_yazari", txtYazar.Text);
                        cmd.Parameters.AddWithValue("@alinma_tarihi", txtTarih.Value);
                        cmd.Parameters.AddWithValue("@kullanici_ismi", txtAKisi.Text);
                        //////////////////////////////////////////////////////////////////
                        cmd1.Parameters.AddWithValue("@kitap_adi", txtAd.Text);
                        cmd1.Parameters.AddWithValue("@kitap_yazari", txtYazar.Text);
                        cmd1.Parameters.AddWithValue("@alinma_tarihi", txtTarih.Value);
                        cmd1.Parameters.AddWithValue("@kullanici_ismi", txtAKisi.Text);
                        string isim = txtAKisi.Text;
                        string ototarih = "UPDATE kitaplar SET geri_getirme_tarihi = DATE_ADD(alinma_tarihi, INTERVAL 2 WEEK)";
                        string ototarih1 = "UPDATE kalici SET geri_getirme_tarihi = DATE_ADD(alinma_tarihi, INTERVAL 2 WEEK)";
                        string arti1kitap = "UPDATE kullanicilar SET okudugu_kitap_sayisi = okudugu_kitap_sayisi + 1 WHERE kullanici_adi ='" + isim + "'";
                        otocmd = new MySqlCommand(ototarih, conn);
                        arti1 = new MySqlCommand(arti1kitap, conn);
                        ototarihkal= new MySqlCommand(ototarih1, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        otocmd.ExecuteNonQuery();
                        arti1.ExecuteNonQuery();
                        ototarihkal.ExecuteNonQuery();
                        conn.Close();
                        VeriGetir();
                        MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    }
                    uyarıForm.Close();
                };

                uyarıForm.Controls.Add(uyarıLabel);
                uyarıForm.Controls.Add(onayCheckBox);
                uyarıForm.Controls.Add(onayButton);

                uyarıForm.ShowDialog();
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "kitap_adi LIKE '" + txtArama.Text + "%'";
            dataGridView1.DataSource = dv;
        }
    }
    
}
