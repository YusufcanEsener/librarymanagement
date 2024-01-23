using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace proje
{
    public partial class kullaniciarayuz : Form
    {
        string username;
        public kullaniciarayuz(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void ReserveBook(int bookId, string userName)
        {
            string query = "UPDATE kitaplar SET rezerve_durumu = TRUE, rezerve_eden_kullanici = 'yusufcan' WHERE kitap_id = @bookId";
            MySqlCommand cmd31 = new MySqlCommand(query, conn);
            cmd31.Parameters.AddWithValue("@userName", userName);
            cmd31.Parameters.AddWithValue("@bookId", bookId);

            try
            {
                cmd31.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla rezerve edildi.");
                VeriGetir(); // DataGridView'i güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap rezerve edilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void kullaniciarayuz_Load(object sender, EventArgs e)
        {
            VeriGetir();
            // "kullanici_adi" sütun başlığını DataGridView'da "Kullanıcı Adı" olarak değiştirme
            dataGridView1.Columns["kitap_adi"].HeaderText = "Kitap Adı";
            dataGridView1.Columns["kitap_id"].HeaderText = "Kitap No";
            dataGridView1.Columns["kitap_yazari"].HeaderText = "Kitap Yazarı";
            dataGridView1.Columns["kullanici_ismi"].HeaderText = "Alan Kişi";
            dataGridView1.Columns["geri_getirme_tarihi"].HeaderText = "Geri Getirme Tarihi";
            dataGridView1.Columns["alinma_tarihi"].HeaderText = "Alınma Tarihi";
            dataGridView1.Columns["rezerve_eden_kullanici"].HeaderText = "Rezerve Eden Kişi";

        }
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        MySqlCommand cmd;
        MySqlCommand cmd31;
        MySqlDataAdapter adapter;
        DataTable dt;
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "kitap_adi LIKE '" + txtArama.Text + "%'";
            dataGridView1.DataSource = dv;
        }
        void VeriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT kitap_id,kullanici_ismi,kitap_adi,kitap_yazari,alinma_tarihi,geri_getirme_tarihi,rezerve_eden_kullanici FROM kitaplar", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris giris=new giris();
            giris.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris giris=new giris();
            giris.Show();
            this.Close();
        }

        private void butonekle_Click(object sender, EventArgs e)
        {
            kullanicibilgi kb = new kullanicibilgi(username);
            kb.ShowDialog();
        }

        private void kullaniciarayuz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                butonekle.PerformClick();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE kitaplar SET rezerve_durumu = TRUE, rezerve_eden_kullanici = @username WHERE kitap_id = @bookId";
            MySqlCommand cmd31 = new MySqlCommand(query, conn);
            cmd31.Parameters.AddWithValue("@username", username);
            cmd31.Parameters.AddWithValue("@bookId", textBox1.Text);
            conn.Open();
            cmd31.ExecuteNonQuery();
            conn.Close();
            VeriGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
