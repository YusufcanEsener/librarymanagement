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
    public partial class adminguncelle : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        MySqlCommand cmd;
        MySqlCommand cmd1;
        MySqlCommand otocmd;
        MySqlCommand arti1;
        MySqlCommand ototarihkal;
        MySqlDataAdapter adapter;
        DataTable dt;
        public adminguncelle()
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

        private void adminguncelle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                butonekle.PerformClick();
            }
        }

        private void adminguncelle_Load(object sender, EventArgs e)
        {
            VeriGetir();
            dataGridView1.Columns["kitap_adi"].HeaderText = "Kitap Adı";
            dataGridView1.Columns["kitap_id"].HeaderText = "Kitap No";
            dataGridView1.Columns["kitap_yazari"].HeaderText = "Kitap Yazarı";
            dataGridView1.Columns["kullanici_ismi"].HeaderText = "Alan Kişi";
            dataGridView1.Columns["geri_getirme_tarihi"].HeaderText = "Geri Getirme Tarihi";
            dataGridView1.Columns["alinma_tarihi"].HeaderText = "Alınma Tarihi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Close();
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
                        string sql = "UPDATE kitaplar SET kitap_adi=@ad,yazar=@yazar,alinma_tarihi=@tarih,alan_kisi=@alankisi WHERE kitap_id=@kitap_id";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                        cmd.Parameters.AddWithValue("@yazar", txtYazar.Text);
                        cmd.Parameters.AddWithValue("@tarih", txtTarih.Value);
                        cmd.Parameters.AddWithValue("@alankisi", txtAKisi.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        VeriGetir();
                        MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                    }
                    uyarıForm.Close();
                };

                uyarıForm.Controls.Add(uyarıLabel);
                uyarıForm.Controls.Add(onayCheckBox);
                uyarıForm.Controls.Add(onayButton);

                uyarıForm.ShowDialog();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtYazar.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtAKisi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTarih.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtgeri.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "kitap_adi LIKE '" + txtArama.Text + "%'";
            dataGridView1.DataSource = dv;
        }
    }
}
